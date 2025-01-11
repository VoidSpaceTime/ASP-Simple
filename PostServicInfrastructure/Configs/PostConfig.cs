using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostServiceDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostServicInfrastructure.Configs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasMany<Comment>(c => c.Comments).WithOne(o => o.OwnerPost).IsRequired();
            builder.HasOne<Category>(c => c.Category).WithMany(o => o.Posts).IsRequired();
            builder.HasMany<Tag>(c => c.Tags).WithMany(o => o.Posts);

        }
    }
}
