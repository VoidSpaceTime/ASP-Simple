using CommonsInitializer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
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
}
