using Commons;
using IdentityServiceDomain;
using IdentityServiceDomain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServiceInfrastructure
{
    public class ServiceAutoDiscover : IServiceAutoDiscover
    {
        public void BuilderService(IServiceCollection services)
        {
            services.AddScoped<IdDomainService>();
            services.AddScoped<IIdRepository, IdRepository>();
        }
    }
}
