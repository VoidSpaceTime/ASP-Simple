using Microsoft.EntityFrameworkCore;

namespace CommonsInitializer
{
    public static class DbContextOptionsBuilderFactory
    {
        public static string ConnicationString = "Server=10.243.222.94;Uid=SQLServer;Pwd=ji123486.*;Database=ASPSimpleDB;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=true;TrustServerCertificate=true;";
        public static DbContextOptionsBuilder<TDbContext> Create<TDbContext>()
            where TDbContext : DbContext
        {
            // 数据库
            //var connStr = Environment.GetEnvironmentVariable("ASPSimpleDB:ConnStr");
            var connStr = ConnicationString;
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionsBuilder.UseSqlServer(connStr);
            return optionsBuilder;
        }
    }


    //public class DbContextFactory : IDbContextFactory<DbContext>
    //{
    //    public DbContext CreateDbContext()
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
    //        var connStr = Environment.GetEnvironmentVariable("ASPSimpleDB:ConnStr");
    //        optionsBuilder.UseSqlServer(connStr);
    //        return new DbContext(optionsBuilder.Options);
    //    }
    //}

}

