using FileServiceDomain;
using FileServiceDomain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServiceInfrastructure
{
    public class FileRepository : IFileRepository
    {
        private readonly FileDbContext dbContext;
        public Task<UploadedItem?> FindFileAsync(long fileSize, string sha256Hash)
        {
            return dbContext.UploadItems.FirstOrDefaultAsync(u => u.FileSizeInBytes == fileSize
    && u.FileSHA256Hash == sha256Hash);
        }

        public Task<UploadedItem?> FindFileAsync(Guid guid)
        {
            return dbContext.UploadItems.FirstOrDefaultAsync(u => u.Id == guid);
        }

        public async Task<List<UploadedItem?>> FindFileListAsync(List<(long fileSize, string sha256Hash)> flieAttrList)
        {
            var list = new List<UploadedItem?>();
            foreach (var item in flieAttrList)
            {
                var result = await dbContext.UploadItems.FirstOrDefaultAsync(u => u.FileSizeInBytes == item.fileSize
           && u.FileSHA256Hash == item.sha256Hash);
                if (result != null)
                {
                    list.Add(result);
                }
            }
            return list;
        }

        public async Task<List<UploadedItem?>> FindFileListAsync(List<Guid> flieIdList)
        {
            var list = new List<UploadedItem?>();
            foreach (var item in flieIdList)
            {
                var result = await dbContext.UploadItems.FirstOrDefaultAsync(u => u.Id == item);
                if (result != null)
                {
                    list.Add(result);
                }
            }
            return list;
        }
    }
}
