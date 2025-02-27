using FileServiceDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServiceDomain
{
    public interface IFileRepository
    {
        /// <summary>
        /// 查找已经上传的相同大小以及散列值的文件记录
        /// </summary>
        /// <param name="fileSize"></param>
        /// <param name="sha256Hash"></param>
        /// <returns></returns>
        Task<UploadedItem?> FindFileAsync(long fileSize, string sha256Hash);
        Task<UploadedItem?> FindFileAsync(Guid guid);

        /// <summary>
        /// 查找已经上传的相同大小以及散列值的文件记录列表
        /// </summary>
        /// <param name="flieAttrList"></param>
        /// <returns></returns>
        Task<List<UploadedItem?>> FindFileListAsync(List<(long fileSize, string sha256Hash)> flieAttrList);
        Task<List<UploadedItem?>> FindFileListAsync(List<Guid> flieIdList);

    }
}
