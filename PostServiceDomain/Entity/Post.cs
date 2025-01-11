using CommonsDomain.Interface;
using CommonsDomain.Models;
using IdentityServiceDomain.Interface;

namespace PostServiceDomain.Entity
{
    public record Post : AggregateRootEntity
    {
        public Post(string title, string context, User ownerUser)
        {
            Title = title;
            Context = context;
            OwnerUser = ownerUser;
            Status = (int)PublicationStatusEnum.Wait;
        }

        public string Title { get; set; }
        public string Context { get; set; }


        public User OwnerUser { get; init; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public int Status { get; set; }
        public Category Category { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();

    }
}
