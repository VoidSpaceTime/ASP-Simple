using Microsoft.AspNetCore.Identity;

namespace IdentityServiceDomain.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
