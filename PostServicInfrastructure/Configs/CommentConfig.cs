using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostServiceDomain.Entity;

namespace PostServicInfrastructure.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("T_Comments");
            builder.HasKey(c => c.Id).IsClustered(false);//对于Guid主键，不要建聚集索引，否则插入性能很差
            builder.HasIndex(e => new { e.OwnerPostId, e.IsDeleted });//索引不要忘了加上IsDeleted，否则会影响性能
            //builder.HasOne<Post>();
            builder.Property(o => o.Content).HasMaxLength(1000).IsUnicode().IsRequired();

        }
    }
}
