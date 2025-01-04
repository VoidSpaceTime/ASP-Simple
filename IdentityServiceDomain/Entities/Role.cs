using IdentityServiceDomain.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServiceDomain.Entities
{
    public class Role : IdentityRole<Guid> ,IHasCreationTime, IHasDeletionTime, ISoftDelete
    {
        public Role()
        {
            this.Id = Guid.NewGuid();
        }

        public DateTime CreationTime => throw new NotImplementedException();

        public DateTime? DeletionTime => throw new NotImplementedException();

        public bool IsDeleted => throw new NotImplementedException();

        public void SoftDelete()
        {
            throw new NotImplementedException();
        }
    }
}
