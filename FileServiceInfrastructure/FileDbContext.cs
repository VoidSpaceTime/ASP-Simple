using CommonsInitializer;
using FileServiceDomain.Entity;
using Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace FileServiceInfrastructure
{
    public class FileDbContext : BaseDbContext
    {
        public DbSet<UploadedItem> UploadItems { get; private set; }

        public FileDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FileDbContext>
    {

        public FileDbContext CreateDbContext(string[] args)
        {
            var opt = DbContextOptionsBuilderFactory.Create<FileDbContext>();
            return new FileDbContext(opt.Options);
        }
    }
}
