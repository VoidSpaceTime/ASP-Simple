using Commons;
using Microsoft.Extensions.DependencyInjection;
using PostServicInfrastructure.Repository;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServicInfrastructure
{
    public class ServiceAutoDiscover : IServiceAutoDiscover
    {
        public void BuilderService(IServiceCollection services)
        {
            services.AddDbContext<PostDbContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(PostRepository<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(CommentRepository<>));
        }
    }
}
