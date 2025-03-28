using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostServiceDomain.Entity;

namespace PostServicInfrastructure.Configs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("T_Posts");
            builder.HasKey(o => o.Id).IsClustered(false);//对于Guid主键，不要建聚集索引，否则插入性能很差
            builder.Property(o => o.Title).HasMaxLength(500).IsUnicode().IsRequired();
            builder.Property(o => o.Content).HasMaxLength(int.MaxValue).IsUnicode().IsRequired();
            builder.HasIndex(e => new { e.TagsId, e.IsDeleted });//索引不要忘了加上IsDeleted，否则会影响性能
            builder.HasIndex(e => new { e.CategoriesId, e.IsDeleted });//索引不要忘了加上IsDeleted，否则会影响性能

            //builder.HasMany<Comment>(c => c.Comments).WithOne(o => o.OwnerPost).IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict); // 避免级联删除;
            //builder.HasMany<Category>(c => c.Categories).WithOne(o => o.OwnerPost)
            //    .OnDelete(DeleteBehavior.Restrict); // 避免级联删除;
            //builder.HasMany<Tag>(c => c.Tags).WithMany(o => o.Posts);
        }
    }
}
