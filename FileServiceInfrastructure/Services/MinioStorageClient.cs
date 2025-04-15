using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using FileServiceDomain;
using FileServiceDomain.Interface;
using MassTransit.Caching.Internals;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;

namespace FileServiceInfrastructure.Services
{
    class MinioStorageClient : IStorageClient
    {
        public StorageType StorageType => StorageType.Public;
        private IOptionsSnapshot<MinioStorageOptions> options; // 测试 是否正确获取配置
        //private IOptions<MinioStorageOptions> minioOptions; // 测试 是否正确获取配置
        //private MinioStorageOptions minioStorage; // 测试 是否正确获取配置

        public MinioStorageClient(IOptionsSnapshot<MinioStorageOptions> options)
        {
            this.options = options;
        }


        public async Task<Uri> SaveAsync(Stream content, string path, CancellationToken cancellationToken = default, FileCategory? category = FileCategory.Other)
        {
            if (path.StartsWith('/'))
            {
                throw new ArgumentException("key should not start with /", nameof(path));
            }
            using MemoryStream ms = new MemoryStream();
            await content.CopyToAsync(ms);
            byte[] bytes = ms.ToArray();
            if (bytes.Length <= 0)
            {
                throw new ArgumentException("file cannot be empty", nameof(content));
            }

            var minioClient = new MinioClient()
                .WithEndpoint(options.Value.Endpoint)
                .WithCredentials(options.Value.AccessKey, options.Value.SecretKey)
                .Build();
            // 检查 bucket 是否存在
            bool found = await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(category.ToString()));
            if (!found)
            {
                // 创建 bucket
                await minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(category.ToString()));
            }
            // 上传文件
            var res = await minioClient.PutObjectAsync(new PutObjectArgs()
             .WithBucket(category.ToString())
             .WithObject(path)
             .WithStreamData(content));
            if (res.ResponseStatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("upload file failed");
            }
            return new Uri($"{options.Value.Endpoint}/{category}/{path}");
        }
    }
}
