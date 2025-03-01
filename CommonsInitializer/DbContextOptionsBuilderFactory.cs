using Microsoft.EntityFrameworkCore;

namespace CommonsInitializer
{
    public static class DbContextOptionsBuilderFactory
    {
        public static string ConnicationString = "Server=10.243.222.94;Uid=sa;Pwd=ji123486.*;Database=ASPSimpleDB;Trusted_Connection=False;MultipleActiveResultSets=True;Encrypt=true;TrustServerCertificate=true;";
        public static DbContextOptionsBuilder<TDbContext> Create<TDbContext>() where TDbContext : DbContext
        {
            // 数据库
            //var connStr = Environment.GetEnvironmentVariable("ASPSimpleDB:ConnStr");
            var connStr = ConnicationString;
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionsBuilder.UseSqlServer(connStr);
            return optionsBuilder;
        }

    }
}

