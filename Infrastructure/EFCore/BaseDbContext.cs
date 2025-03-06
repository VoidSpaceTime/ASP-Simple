using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
  /*    // 使用反射注入所有数据库 故注释
   *    /// <summary>
        /// 配置数据库连接
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            //var connStr = Environment.GetEnvironmentVariable("ASPSimpleDB:ConnStr");
            var connStr = DbContextOptionsBuilderFactory.ConnicationString;
            optionsBuilder.UseSqlServer(connStr);
            //optionsBuilder.UseSqlServer("Server=.;Database=Demo1;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=true;TrustServerCertificate=true;");
        }*/
    }
}
