﻿using CommonsInitializer;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PostServiceDomain.Entity;

namespace PostServicInfrastructure
{
    public class PostDbContext : BaseDbContext
    {
        public DbSet<Post> Posts { get; private set; }
        public DbSet<Comment> Comments { get; private set; }
        public DbSet<Tag> Tags { get; private set; }
        public DbSet<Category> Categories { get; private set; }

        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PostDbContext>
    //{

    //    public PostDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = DbContextOptionsBuilderFactory.Create<PostDbContext>();


    //        return new PostDbContext(optionsBuilder.Options);
    //    }
    //}
}
