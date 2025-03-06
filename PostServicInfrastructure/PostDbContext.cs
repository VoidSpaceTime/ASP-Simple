using CommonsInitializer;
using Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PostServiceDomain.Entity;

namespace PostServicInfrastructure
{
    public class PostDbContext : BaseDbContext
    {
        public DbSet<Post> Posts { get; private set; }
        public DbSet<Comment> Comments { get; private set; }
        //public DbSet<Tag> Tags { get; private set; }
        public DbSet<Category> Categories { get; private set; }

        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        //{
      
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=ASPSimpleDB;Trusted_Connection=True;");
        //    }

        //}

    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PostDbContext>
    {

        public PostDbContext CreateDbContext(string[] args)
        {
            //var optionsBuilder = DbContextOptionsBuilderFactory.Create<PostDbContext>();
            // 测试是否可以连接数据库
            var opt = DbContextOptionsBuilderFactory.Create<PostDbContext>();
            // 原方法
            //var optionsBuilder = new DbContextOptionsBuilder<PostDbContext>();
            //optionsBuilder.UseSqlServer("Server=.;Database=ASPSimpleDB;Trusted_Connection=True;");
            return new PostDbContext(opt.Options);
        }
    }
}
