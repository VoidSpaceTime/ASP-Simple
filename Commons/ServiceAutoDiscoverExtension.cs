using Microsoft.Extensions.DependencyInjection;

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
