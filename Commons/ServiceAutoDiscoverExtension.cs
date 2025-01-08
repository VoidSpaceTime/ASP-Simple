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

            var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(e => e.GetTypes())
                .Where(t => typeof(IServiceAutoDiscover).IsAssignableFrom(t) && t.IsClass)
                .ToList();


            foreach (var type in allTypes)
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
