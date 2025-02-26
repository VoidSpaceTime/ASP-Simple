using FileServiceDomain;
using FileServiceDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServiceInfrastructure
{
    public class FileRepository : IFileRepository
    {
        public Task<UploadedItem?> FindFileAsync(long fileSize, string sha256Hash)
        {
            throw new NotImplementedException();
        }

        public Task<UploadedItem?> FindFileAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<List<UploadedItem?>> FindFileListAsync(List<Dictionary<long, string>> flieAttrList)
        {
            throw new NotImplementedException();
        }

        public Task<List<UploadedItem?>> FindFileListAsync(List<Guid> flieIdList)
        {
            throw new NotImplementedException();
        }
    }
}
