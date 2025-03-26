using CommonsDomain.Entities;
using CommonsDomain.Models;

namespace PostServiceDomain.Entity
{
    public record Comment : AggregateRootEntity
    {
        public Comment()
        {
            Content = string.Empty;
            OwnerUser = new User();
            OwnerPost = new Post();
        } // 无参数构造函数

        public Comment(Post post, string content, User ownerUser)
        {
            OwnerPost = post;
            Content = content;
            OwnerUser = ownerUser;
            Status = (int)PublicationStatusEnum.Wait;
        }

        public string Content { get; set; }
        public User OwnerUser { get; init; }
        public Post OwnerPost { get; set; }
        public int Status { get; set; }
    }
}
