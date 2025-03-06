using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace CommonsInitializer
{
    public static class DbContextOptionsBuilderFactory
    {

        /// <summary>
        /// 设计时 使用数据库链接
        /// 从环境变量中获取数据库链接 更新数据配置
        /// <returns></returns>

        public static DbContextOptionsBuilder<TDbContext> Create<TDbContext>() where TDbContext : DbContext
        {
            var connStr = Environment.GetEnvironmentVariable("ASPSimpleDB:ConnStr");
            //var connStr = "ConnicationString";
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionsBuilder.UseSqlServer(connStr);
            return optionsBuilder;
        }

    }
}

