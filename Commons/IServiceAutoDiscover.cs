using Microsoft.Extensions.DependencyInjection;

namespace Commons
{
    public interface IServiceAutoDiscover
    {
        void BuilderService(IServiceCollection services);
    }
}
