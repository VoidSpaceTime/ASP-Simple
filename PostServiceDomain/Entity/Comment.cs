using CommonsDomain.Interface;
using CommonsDomain.Models;
using IdentityServiceDomain.Interface;

namespace PostServiceDomain.Entity
{
    public record Comment : AggregateRootEntity

    {
        public Comment(Post post, string context, User ownerUser)
        {
            OwnerPost = post;
            Context = context;
            OwnerUser = ownerUser;
            Status = (int)PublicationStatusEnum.Wait;
        }
        public string Context { get; set; }
        public User OwnerUser { get; init; }
        public Post OwnerPost { get; set; }
        public int Status { get; set; }
    }
}
