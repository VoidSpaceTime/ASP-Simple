using CommonsDomain.Interface;
using IdentityServiceDomain.Interface;
using Microsoft.AspNetCore.Identity;
namespace CommonsDomain.Entities
{
    public class User : IdentityUser<Guid>, IHasCreationTime, IHasDeletionTime, ISoftDelete
    {
        public User() { } // 添加默认构造函数
        public DateTime CreationTime { get; init; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; private set; }

        public User(string userName) : base(userName)
        {
            Id = Guid.NewGuid();
            CreationTime = DateTime.Now;
        }

        public void SoftDelete()
        {
            this.IsDeleted = true;
            this.DeletionTime = DateTime.Now;
        }
    }
}