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
        public static ConfigurationManager AddEntityConfiguration(this ConfigurationManager manager) // 使用 this 关键字使其成为扩展方法
        {
            // 从配置管理器中获取连接字符串
            var connectionString = manager.GetConnectionString("DefaultDB:ConnStr");

            // 将 ConfigurationManager 转换为 IConfigurationBuilder 接口
            IConfigurationBuilder configBuilder = manager;
            // 使用连接字符串添加一个新的 EntityConfigurationSource 配置源
            configBuilder.Add(new EntityConfigurationSource(connectionString));

            // 返回修改后的 ConfigurationManager 实例
            return manager;
        }
    }
}
