using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostServiceDomain.Entity;

namespace PostServicInfrastructure.Configs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(o => o.Id).IsClustered(false);

            builder.HasMany<Comment>(c => c.Comments).WithOne(o => o.OwnerPost).IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // 避免级联删除;
            builder.HasMany<Category>(c => c.Categories).WithOne(o => o.OwnerPost)
                 .OnDelete(DeleteBehavior.Restrict); // 避免级联删除;
            //builder.HasMany<Tag>(c => c.Tags).WithMany(o => o.Posts);

        }
    }
}
