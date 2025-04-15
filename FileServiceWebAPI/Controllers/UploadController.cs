using CommonsDomain.DTO;
using FileServiceDomain;
using FileServiceInfrastructure;
using FileServiceWebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio.DataModel;

namespace FileServiceWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "User,Admin")]
    public class UploadController : ControllerBase
    {
        private readonly FileDbContext dbContext;
        private readonly FileDomainService domainService;
        private readonly IFileRepository repository;

        public UploadController(FileDbContext dbContext, FileDomainService domainService, IFileRepository repository)
        {
            this.dbContext = dbContext;
            this.domainService = domainService;
            this.repository = repository;
        }
        [HttpGet]
        public async Task<JsonResponseL> FileExists(long fileSize, string sha256Hash)
        {
            var res = new JsonResponseL();
            var file = await repository.FindFileAsync(fileSize, sha256Hash);
            if (file == null)
            {
                return res.Succeed(new FileExistsResponse(false, null));
            }
            else
            {
                return res.Succeed(new FileExistsResponse(true, file.RemoteUrl));
            }
        }
        [HttpPost]
        public async Task<JsonResponseL> UploadFile(UploadRequest request, CancellationToken cancellationToken = default)
        {
            var res = new JsonResponseL();
            var file = request.File;
            var category = request.Category;
            string fileName = file.FileName;
            using Stream stream = file.OpenReadStream();
            var uploadedItem = await domainService.UploadAsync(stream, fileName, cancellationToken, category);
            dbContext.Add(uploadedItem);
            return res.Succeed(uploadedItem.RemoteUrl ?? new Uri(""));
        }
    }
}
