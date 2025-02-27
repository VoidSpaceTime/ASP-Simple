using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServiceDomain.Interface
{
    public interface IStorageClient
    {
        StorageType StorageType { get; }

        /// <summary>
        /// 保存文件到存储设备
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>存储返回的可以被访问的文件Url</returns>
        Task<Uri> SaveAsync(Stream content, string path, CancellationToken cancellationToken = default, FileCategory? category = FileCategory.Other);

    }
}
