using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConfigurationProvider
{

    // 定义一个密封类 EntityConfigurationContext，继承自 DbContext
    // 使用 C# 12.0 的记录类语法，接收一个可空的连接字符串参数
    public sealed class EntityConfigurationContext(string? connectionString) : DbContext
    {
        // 定义一个 DbSet 属性，用于访问 Settings 实体
        public DbSet<Settings> Settings => Set<Settings>();

        // 重写 OnConfiguring 方法，用于配置数据库连接选项
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 使用 switch 表达式，根据连接字符串是否为空来配置数据库连接
            _ = connectionString switch
            {
                // 如果连接字符串不为空，则使用 SQL Server 数据库
                { Length: > 0 } => optionsBuilder.UseSqlServer(connectionString),
                // 否则，使用内存数据库
                _ => optionsBuilder.UseInMemoryDatabase("InMemoryDatabase")
            };
        }
    }
}
