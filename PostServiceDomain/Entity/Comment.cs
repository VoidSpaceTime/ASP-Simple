using CommonsDomain.Interface;
using IdentityServiceDomain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostServiceDomain.Entity
{
    public class Comment : IHasCreationTime, IHasDeletionTime, ISoftDelete, IOwnerUser

    {
        public Comment(string context, User ownerUser)
        {
            Context = context;
            OwnerUser = ownerUser;
            CreationTime = DateTime.Now;
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

    }
}
