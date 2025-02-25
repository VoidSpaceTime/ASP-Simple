using FileServiceDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServiceDomain
{
    public class FileDomainService
    {
        private readonly IFileRepository fileRepository;
        FileDomainService(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public async Task<File> GetFileByIdAsync(Guid guid)
        {
            return await fileRepository.FindAsync(guid);
        }
    }
}
