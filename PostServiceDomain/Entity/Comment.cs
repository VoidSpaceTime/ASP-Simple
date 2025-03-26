using CommonsDomain.Entities;
using CommonsDomain.Models;

namespace PostServiceDomain.Entity
{
    public record Comment : AggregateRootEntity
    {
        public Comment()
        {
            Content = string.Empty; // 初始化 Content
        } // 无参数构造函数

        public Comment(Guid postId, string content, Guid ownerUserId)
        {
            OwnerPostId = postId;
            Content = content;
            OwnerUserId = ownerUserId;
            Status = (int)PublicationStatusEnum.Wait;
        }

        public string Content { get; set; }
        public Guid OwnerUserId { get; init; }

        public Guid OwnerPostId { get; set; }
        public int Status { get; set; }
    }
}
