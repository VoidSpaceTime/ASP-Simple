using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class ServiceAutoDiscoverExtension
    {
        public static IServiceCollection AddServiceAutoDiscover(this IServiceCollection services)
        {
            // 获取当前程序集中所有实现  接口的类型

            var types = AppDomain.CurrentDomain.GetAssemblies();

   
            // 创建实例并调用方法
            //foreach (var type in types)
            //{
            //    IServiceAutoDiscover instance = (IServiceAutoDiscover)Activator.CreateInstance(type);
            //    if (instance == null)
            //    {
            //        throw new ApplicationException($"Cannot create ${type}");
            //    }
            //    instance.BuilderService(services);
            //}
            return services;
        }
    }
    /*
         public static class ServiceAutoDiscoverExtension
        {
            public static IServiceCollection AddServiceAutoDiscover(this IServiceCollection services)
            {
                // 发布环境使用。
                var context = DependencyContext.Default.RuntimeLibraries;

                var projectAssemblyNames = context.Where(e => e.Type == "project").Select(e => e.Name);

                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(e => projectAssemblyNames.Contains(e.GetName().Name ?? "Unknow")).ToList();
                var allTypes = assemblies
                    .SelectMany(assembly => assembly.GetTypes().Where(type => type.IsClass && !type.IsSealed && !type.IsAbstract && type.IsPublic && type.IsDefined(typeof(ServiceAutoDiscoverAttribute), false)))
                    .ToList();
                foreach (var type in allTypes)
                {
                    var attribute = type.GetCustomAttribute<ServiceAutoDiscoverAttribute>()!;

                    switch (attribute.Life)
                    {
                        case 1:
                            services.AddScoped(attribute.ImplementationInterface, type);
                            break;
                        case 2:
                            services.AddSingleton(attribute.ImplementationInterface, type);
                            break;
                        case 3:
                            services.AddTransient(attribute.ImplementationInterface, type);
                            break;
                        default:
                            throw new Exception($"{type.Name} 自动注入失败，请检查代码");
                    }

                }

                return services;
            }
        }
    */
}
