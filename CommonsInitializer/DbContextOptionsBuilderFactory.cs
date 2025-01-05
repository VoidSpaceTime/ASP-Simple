using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsInitializer
{
    public static class DbContextOptionsBuilderFactory
    {
        public static DbContextOptionsBuilder<TDbContext> Create<TDbContext>()
            where TDbContext : DbContext
        {
            var connStr = Environment.GetEnvironmentVariable("ASPSimpleDB:ConnStr");
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=YouzackVNextDB;User ID=sa;Password=dLLikhQWy5TBz1uM;");
            optionsBuilder.UseSqlServer(connStr);
            return optionsBuilder;
        }
    }


    public class DbContextFactory : IDbContextFactory<DbContext>
    {
        public DbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            var connStr = Environment.GetEnvironmentVariable("ASPSimpleDB:ConnStr");
            optionsBuilder.UseSqlServer(connStr);
            return new DbContext(optionsBuilder.Options);
        }
    }

}

