using Commons;
using Microsoft.Extensions.DependencyInjection;
using PostServiceDomain;
using PostServiceDomain.Entity;
using PostServiceDomain.Interface;
using PostServicInfrastructure.Repository;
using static PostServiceDomain.Interface.IBaseRepository;

namespace PostServicInfrastructure
{
    public class ServiceAutoDiscover : IServiceAutoDiscover
    {
        public void BuilderService(IServiceCollection services)
        {
            //services.AddDbContext<PostDbContext>();
            //services.AddScoped<PostRepository<Post>>();
            //services.AddScoped<CommentRepository<Comment>>();

            //services.AddScoped<PostDomainService>();


            //services.AddScoped<IPostRepository, PostRepository>(); // 确保注册 IPostRepository
            //services.AddScoped(typeof(IBaseRepository<>), typeof(PostRepository<>));
            //services.AddScoped(typeof(IBaseRepository<>), typeof(CommentRepository<>));


            services.AddScoped<IBaseRepository<Post>, PostRepository>();
            services.AddScoped<IBaseRepository<Comment>, CommentRepository>();
            //services.AddDbContext<PostDbContext>();
            services.AddScoped<PostDomainService>();
            services.AddScoped<CommentDomainService>();
            //services.AddScoped<CategoryDomainService>();
            //services.AddScoped<TagDomainService>();
        }
    }
}
