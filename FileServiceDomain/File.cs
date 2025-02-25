using CommonsDomain.Entities;
using CommonsDomain.Models;

namespace FileServiceDomain
{
    public record File : AggregateRootEntity
    {
        public File() { } // 无参数构造函数
        public File(string path, string fileName)
        {
            Path = path;
            FileName = fileName;
        }
        public string Path { get; set; }
        public string FileName { get; set; }
    }
}
