using Commons;
using Microsoft.Extensions.DependencyInjection;

namespace JWT
{
    public class ServiceAutoDiscover : IServiceAutoDiscover
    {
        public void BuilderService(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
