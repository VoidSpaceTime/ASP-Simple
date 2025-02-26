using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServiceDomain;
using FileServiceDomain.Interface;

namespace FileServiceInfrastructure.Services
{
    class MinioStorageClient : IStorageClient
    {
        public StorageType StorageType => throw new NotImplementedException();

        public Task<Uri> SaveAsync(string savePath, Stream content, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
