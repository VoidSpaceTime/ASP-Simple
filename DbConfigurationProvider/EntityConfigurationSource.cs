using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DbConfigurationProvider
{
    // IConfigurationSource 负责创建 IConfigurationProvider 实现的实例。它的定义很简单，就一个Build方法
    public sealed class EntityConfigurationSource : IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> action;

        public EntityConfigurationSource(Action<DbContextOptionsBuilder> action)
        {
            this.action = action;
        }

        // 构建配置提供程序
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new EntityConfigurationProvider(this.action);
        }
    }

}
