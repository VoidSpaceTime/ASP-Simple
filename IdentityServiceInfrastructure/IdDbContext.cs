using CommonsDomain.Entities;
using CommonsInitializer;
using IdentityServiceDomain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace IdentityServiceInfrastructure
{
    public class IdDbContext : IdentityDbContext<User, Role, Guid>
    {
        public IdDbContext(DbContextOptions<IdDbContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            //modelBuilder.EnableSoftDeletionGlobalFilter();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);

            //var connStr = Environment.GetEnvironmentVariable("ASPSimpleDB:ConnStr");
            var connStr = DbContextOptionsBuilderFactory.ConnicationString;
            optionsBuilder.UseSqlServer(connStr);
            //optionsBuilder.UseSqlServer("Server=.;Database=Demo1;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=true;TrustServerCertificate=true;");
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdDbContext>
    {

        public IdDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = DbContextOptionsBuilderFactory.Create<IdDbContext>();


            return new IdDbContext(optionsBuilder.Options);
        }
    }
}

// Add-Migration
// Update-Database