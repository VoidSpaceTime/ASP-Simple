using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DbConfigurationProvider
{
    // 实现IConfigurationSource接口的类，用于提供配置源
    public sealed class EntityConfigurationSource(string? connectionString) : IConfigurationSource
    {
        // 构建配置提供程序
        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new EntityConfigurationProvider(connectionString);
    }

    // 实现ConfigurationProvider的类，用于从数据库加载配置
    public sealed class EntityConfigurationProvider(string? connectionString) : ConfigurationProvider
    {
        // 加载配置数据
        public override void Load()
        {
            // 创建数据库上下文
            using var dbContext = new EntityConfigurationContext(connectionString);

            // 确保数据库已创建
            dbContext.Database.EnsureCreated();

            // 如果数据库中有设置，则加载它们，否则创建并保存默认值
            Data = dbContext.Settings.Any()
                ? dbContext.Settings.ToDictionary(
                    static c => c.Key,
                    static c => c.Value, StringComparer.OrdinalIgnoreCase)
                : CreateAndSaveDefaultValues(dbContext);
        }

        // 创建并保存默认配置值
        static Dictionary<string, string?> CreateAndSaveDefaultValues(EntityConfigurationContext context)
        {
            // 定义默认配置值
            var settings = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase)
            {
                ["WidgetOptions:EndpointId"] = "b3da3c4c-9c4e-4411-bc4d-609e2dcc5c67",
                ["WidgetOptions:DisplayLabel"] = "Widgets Incorporated, LLC.",
                ["WidgetOptions:WidgetRoute"] = "api/widgets"
            };

            // 将默认配置值添加到数据库
            context.Settings.AddRange([.. settings.Select(static kvp => new Settings(kvp.Key, kvp.Value))]);

            // 保存更改
            context.SaveChanges();

            // 返回默认配置值
            return settings;
        }
    }
}
