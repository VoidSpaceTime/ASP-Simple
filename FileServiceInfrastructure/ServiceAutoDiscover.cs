using Commons;
using FileServiceDomain;
using FileServiceDomain.Interface;
using FileServiceInfrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServiceInfrastructure
{
    public class ServiceAutoDiscover : IServiceAutoDiscover
    {
        public void BuilderService(IServiceCollection services)
        {
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IStorageClient, MinioStorageClient>();
            services.AddScoped<FileDomainService>();

        }
    }
}
