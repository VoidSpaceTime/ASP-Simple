﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostServiceDomain.Entity;

namespace PostServicInfrastructure.Configs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasMany<Comment>(c => c.Comments).WithOne(o => o.OwnerPost).IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // 避免级联删除;
            builder.HasOne<Category>(c => c.Category).WithMany(o => o.Posts).IsRequired()
                 .OnDelete(DeleteBehavior.Restrict); // 避免级联删除;
            builder.HasMany<Tag>(c => c.Tags).WithMany(o => o.Posts);

        }
    }
}
