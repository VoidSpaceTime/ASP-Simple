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



        public string Content { get; set; }
        public Guid OwnerUserId { get; init; }

        public Guid OwnerPostId { get; set; }
        public PublicationStatusEnum Status { get; set; }

        public static Comment Create(string content, Guid ownerUserId, Guid ownerPostId)
        {
            return new Comment()
            {
                Content = content,
                OwnerUserId = ownerUserId,
                OwnerPostId = ownerPostId,
                Status = PublicationStatusEnum.Wait,
            };
        }
    }
}
