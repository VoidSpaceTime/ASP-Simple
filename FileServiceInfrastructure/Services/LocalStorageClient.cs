using FileServiceDomain;
using FileServiceDomain.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServiceInfrastructure.Services
{
    class LocalStorageClient : IStorageClient
    {
        public StorageType StorageType => StorageType.Backup;
        private readonly IWebHostEnvironment hostEnv;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LocalStorageClient(IWebHostEnvironment hostEnv, IHttpContextAccessor httpContextAccessor)
        {
            this.hostEnv = hostEnv;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Uri> SaveAsync(Stream content, string path, CancellationToken cancellationToken = default, FileCategory? category = FileCategory.Other)
        {
            if (path.StartsWith('/'))
            {
                throw new ArgumentException("key should not start with /", nameof(path));
            }
            // 获取工作目录路径
            string workingDir = Path.Combine(hostEnv.ContentRootPath, "wwwroot");
            // 获取完整文件路径
            string fullPath = Path.Combine(workingDir, path);
            // 获取文件所在目录
            string? fullDir = Path.GetDirectoryName(fullPath);
            // 如果目录不存在，则自动创建
            if (!Directory.Exists(fullDir) && fullDir!=null)
            {
                Directory.CreateDirectory(fullDir);
            }
            // 如果文件已存在，则尝试删除
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            // 将内容复制到文件中
            await content.CopyToAsync(content, cancellationToken);
            // 获取当前请求
            var req = httpContextAccessor.HttpContext!.Request;
            // 构建文件访问的URL
            string url = req.Scheme + "://" + req.Host + "/FileService/" + path;
            // 返回文件访问的URL
            return new Uri(url);
        }
    }
}
