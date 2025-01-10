using CommonsDomain.Interface;
using IdentityServiceDomain.Interface;

namespace PostServiceDomain.Entity
{
    public class Comment : IHasCreationTime, IHasDeletionTime, ISoftDelete, IOwnerUser
            , IPublicationStatus

    {
        public Comment(Post post, string context, User ownerUser)
        {
            OwnerPost = post;
            Context = context;
            OwnerUser = ownerUser;
            CreationTime = DateTime.Now;
            Status = (int)PublicationStatusEnum.Wait;
        }
        public int Id { get; set; }
        public string Context { get; set; }
        public User OwnerUser { get; init; }
        public bool IsDeleted { get; private set; }

        public DateTime CreationTime { get; init; }

        public DateTime? DeletionTime { get; set; }
        public void SoftDelete()
        {
            this.IsDeleted = true;
            this.DeletionTime = DateTime.Now;
        }
        public Post OwnerPost { get; set; }
        public int Status { get; set; }
    }
}
