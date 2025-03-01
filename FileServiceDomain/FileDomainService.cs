using Commons;
using FileServiceDomain.Entity;
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
        private readonly IStorageClient backupStorage;//备份服务器
        private readonly IStorageClient remoteStorage;//文件存储服务器
        FileDomainService(IFileRepository fileRepository, IEnumerable<IStorageClient> storageClients)
        {
            this.fileRepository = fileRepository;
            //用这种方式可以解决内置DI不能使用名字注入不同实例的问题，而且从原则上来讲更加优美
            backupStorage = storageClients.First(c => c.StorageType == StorageType.Backup);
            remoteStorage = storageClients.First(c => c.StorageType == StorageType.Public);
        }
        public async Task<UploadedItem> UploadAsync(Stream stream, string fileName, CancellationToken cancellationToken, FileCategory? fileCategory)
        {
            string sha256Hash = HashHelper.ComputeSha256Hash(stream);
            long fileSize = stream.Length;
            DateTime today = DateTime.Today;
            string extension = Path.GetExtension(fileName);
            //查询是否有和上传文件的大小和SHA256一样的文件，如果有的话，就认为是同一个文件
            //虽然说前端可能已经调用FileExists接口检查过了，但是前端可能跳过了，或者有并发上传等问题，所以这里再检查一遍。
            var oldUploadItem = await fileRepository.FindFileAsync(fileSize, sha256Hash);
            if (oldUploadItem != null)
            {
                return oldUploadItem;
            }
            Guid id = Guid.NewGuid();
            //**用日期把文件分散在不同文件夹存储，同时由于加上了文件hash值作为目录，又用用户上传的文件夹做文件名，
            //**所以几乎不会发生不同文件冲突的可能
            //**用用户上传的文件名保存文件名，这样用户查看、下载文件的时候，文件名更灵活
            // 我不同意 , 我非要用GUID作为文件名
            string savePath = $"{today.Year}/{today.Month}/{today.Day}/{sha256Hash + extension}";
            stream.Position = 0;
            //backupStorage实现很稳定、速度很快，一般都使用本地存储（文件共享或者NAS）
            //Uri backupUrl = await backupStorage.SaveAsync(stream, savePath, cancellationToken, fileCategory);//保存到本地备份 // 懒不写 本地储存了, 反正都是需要存储服务
            stream.Position = 0;
            Uri remoteUrl = await remoteStorage.SaveAsync(stream, savePath, cancellationToken, fileCategory);//保存到生产的存储系统
            var backupUrl = remoteUrl;
            stream.Position = 0;
            //领域服务并不会真正的执行数据库插入，只是把实体对象生成，然后由应用服务和基础设施配合来真正的插入数据库！
            //DDD中尽量避免直接在领域服务中执行数据库的修改（包含删除、新增）操作。
            return UploadedItem.Create(id, savePath, fileSize, sha256Hash, backupUrl, remoteUrl);

        }
    }
}
