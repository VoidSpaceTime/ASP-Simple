using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DbConfigurationProvider;
namespace Infrastructure.EFCore
{
    /// <summary>
    /// EF Core 初始化帮助类
    /// </summary>
    public static class EFCoreInitializerHelper
    {
        /// <summary>
        /// 注册所有程序集中的DbContext
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="builder">DbContext配置构建器</param>
        /// <param name="assemblies">要搜索的程序集集合</param>
        /// <returns>服务集合</returns>
        public static IServiceCollection AddAllDbContexts(this IServiceCollection services, Action<DbContextOptionsBuilder> builder, IEnumerable<Assembly> assemblies, bool enableLazyLoading = false)
        {
            // AddDbContextPool不支持DbContext注入其他对象，而且使用不当有内存暴涨的问题，因此不用AddDbContextPool
            // 定义AddDbContext方法的参数类型
            Type[] types = new Type[] { typeof(IServiceCollection), typeof(Action<DbContextOptionsBuilder>), typeof(ServiceLifetime), typeof(ServiceLifetime) };
            // 通过反射获取AddDbContext方法
            var methodAddDbContext = typeof(EntityFrameworkServiceCollectionExtensions)
             .GetMethod(nameof(EntityFrameworkServiceCollectionExtensions.AddDbContext), 1, types);

            // 尝试启用懒加载
            // 如果启用懒加载，创建一个新的builder来包装原来的builder
            Action<DbContextOptionsBuilder> dbContextBuilder = builder;
            if (enableLazyLoading)
            {
                dbContextBuilder = options =>
                {
                    // 先调用原始builder
                    builder(options);
                    // 启用懒加载代理
                    options.UseLazyLoadingProxies();
                };
            }
            foreach (var asmToLoad in assemblies)
            {
                // 获取程序集中所有类型
                Type[] typesInAsm = asmToLoad.GetTypes();
                // 注册DbContext
                // GetTypes()包含public和protected类型
                // GetExportedTypes只包含public类型
                // 这样聚合根中的XXDbContext可以是internal的以保持隔离
                var ass = typesInAsm.Where(t => !t.IsAbstract && typeof(DbContext).IsAssignableFrom(t) && !typeof(DbContextIgnore).IsAssignableFrom(t));
                /*             var ass = typesInAsm.Where(t => !t.IsAbstract && typeof(DbContext).IsAssignableFrom(t) &&
                                 t.GetConstructors().Any(c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType.IsGenericType &&
                                     c.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(DbContextOptions<>)
                                 )
                             );*/
                foreach (var dbCtxType in ass)
                {
                    // 类似于serviceCollection.AddDbContext<SomeDbContext>(opt=>...)的操作
                    var methodGenericAddDbContext = methodAddDbContext!.MakeGenericMethod(dbCtxType);
                    // 调用反射方法注册DbContext，生命周期为Scoped
                    methodGenericAddDbContext.Invoke(null, new object[] { services, builder, ServiceLifetime.Scoped, ServiceLifetime.Scoped });
                }
            }
            return services;
        }
    }
}
