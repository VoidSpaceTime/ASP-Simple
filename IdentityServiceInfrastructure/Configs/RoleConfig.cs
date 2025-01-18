using IdentityServiceDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServiceInfrastructure.Configs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //builder.ToTable("T_Roles");
        }
    }
}
