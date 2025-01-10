using CommonsDomain.Interface;
using IdentityServiceDomain.Interface;

namespace PostServiceDomain.Entity
{
    public class Post : IHasCreationTime, IHasDeletionTime, ISoftDelete, IOwnerUser
            , IPublicationStatus
    {
        public Post(string title, string context, User ownerUser)
        {
            Title = title;
            Context = context;
            CreationTime = DateTime.Now;
            OwnerUser = ownerUser;
            Status = (int)PublicationStatusEnum.Wait;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public bool IsDeleted { get; private set; }

        public DateTime CreationTime { get; init; }

        public DateTime? DeletionTime { get; set; }
        public void SoftDelete()
        {
            this.IsDeleted = true;
            this.DeletionTime = DateTime.Now;
        }

        public User OwnerUser { get; init; }
        public List<Comment>? Comments { get; set; }
        public int Status { get; set; }


    }
}
