using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConfigurationProvider
{
    // 定义一个静态类 ConfigurationManagerExtensions
    public static class ConfigurationManagerExtensions
    {
        // 扩展方法 AddEntityConfiguration，扩展 ConfigurationManager 类
   /*     public static IConfigurationBuilder AddEntityConfiguration(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> optionAction) // 使用 this 关键字使其成为扩展方法
        {
            // 从配置管理器中获取连接字符串
            //var connectionString = manager.GetConnectionString("DefaultDB:ConnStr");
            var connectionString = "Server=10.60.71.213;Uid=sa;Pwd=mssql_wpxJsp;Database=DefaultConfigDB;Trusted_Connection=False;MultipleActiveResultSets=True;Encrypt=true;TrustServerCertificate=true;";

            // 将 ConfigurationManager 转换为 IConfigurationBuilder 接口
            // 使用连接字符串添加一个新的 EntityConfigurationSource 配置源

            // 返回修改后的 ConfigurationManager 实例
            builder.Add(new EntityConfigurationSource(optionAction));
            return builder;
        }*/
        // 微软方案
        public static ConfigurationManager AddEntityConfiguration(this ConfigurationManager manager)
        {
            //var connectionString = manager.GetConnectionString("WidgetConnectionString");
            var connectionString = Environment.GetEnvironmentVariable("DefaultDB:ConnStr");

            IConfigurationBuilder configBuilder = manager;
            configBuilder.Add(new EntityConfigurationSource(connectionString));

            return manager;
        }
    }



}
