using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using System.Security.Cryptography;

namespace Commons
{

    public static class ServiceAutoDiscoverExtension
    {
        public static IServiceCollection AddServiceAutoDiscover(this IServiceCollection services)
        {

            //// 获取引用的程序集并过滤
            //var referencedAssemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies()
            //    .Where(x => !x.Name.StartsWith("Microsoft.") && !x.Name.StartsWith("System."))
            //    .Select(Assembly.Load);

            //// 发现实现 IServiceAutoDiscover 接口的类
            //var autoDiscoverServices = new List<Type>();
            //foreach (var assembly in referencedAssemblies)
            //{
            //    var types = assembly.GetTypes()
            //        //.Where(t => typeof(IServiceAutoDiscover).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            //        .Where(t => t.GetInterfaces().Any(iface => iface == typeof(IServiceAutoDiscover)) && t.IsClass && !t.IsAbstract)
            //        ;

            //    autoDiscoverServices.AddRange(types);
            //}


            var dpls2 = DependencyContext.Default.CompileLibraries
                .Where(l => !l.Serviceable && l.Type != "package" && l.Type == "project")
                .Select(l => Assembly.Load(new AssemblyName(l.Name)).GetTypes().Where(t => typeof(IServiceAutoDiscover).IsAssignableFrom(t) && t.IsClass))
                .SelectMany(a=>a);
                //.SelectMany(a=>a);
  

            /// 这个有缺陷, 未执行的函数获取不到
            //var allTypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(e => e.GetTypes())
            //    .Where(t => typeof(IServiceAutoDiscover).IsAssignableFrom(t) && t.IsClass)
            //    .ToList();

            foreach (var type in dpls2)
            {
                var obj = (IServiceAutoDiscover?)Activator.CreateInstance(type);
                if (obj != null)
                {
                    obj.BuilderService(services);
                }

            }

            return services;
        }
    }

}
