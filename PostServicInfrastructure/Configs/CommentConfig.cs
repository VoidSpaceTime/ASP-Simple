using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostServiceDomain.Entity;

namespace PostServicInfrastructure.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("T_Comment");
            //builder.HasKey(c => c.Id);
            builder.Property(o => o.Context).HasMaxLength(500).IsRequired();
        }
    }
}
