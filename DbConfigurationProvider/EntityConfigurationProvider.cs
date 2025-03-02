using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DbConfigurationProvider
{
    /*如果我们需要封装自己的配置提供程序，推荐直接继承抽象类 ConfigurationProvider，该类实现了 IConfigurationProvider 接口，
        * 继承自该类只要实现 Load 方法即可，Load 方法用于从配置来源加载解析配置信息，将最终的键值对配置信息存储到 Data 中。
        * 这个过程中可参考一下其他已有的配置提供程序的源码，模仿着去写自己的东西。
        */
    // IConfigurationProvider 负责实现配置的设置、读取、重载等功能，并以键值对形式提供配置。
    public sealed class EntityConfigurationProvider : ConfigurationProvider
    {
        Action<DbContextOptionsBuilder> OptionsAction { get; }

        public EntityConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        // 加载配置数据
        public override void Load()
        {
            // 创建数据库上下文
            var builder = new DbContextOptionsBuilder<EntityConfigurationContext>();

            OptionsAction(builder);
            using var dbContext = new EntityConfigurationContext(builder.Options);
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
            context.Settings.AddRange([.. settings.Select(static kvp => new Config(kvp.Key, kvp.Value))]);

            // 保存更改
            context.SaveChanges();

            // 返回默认配置值
            return settings;
        }
    }
}
