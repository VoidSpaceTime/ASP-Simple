using Commons;
using DbConfigurationProvider;
using JWT;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CommonsInitializer
{
    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// 链接配置数据库 , 从数据库中获取配置
        /// </summary>
        /// <param name="builder">Web 应用程序构建器</param>
        public static void ConfigureDbConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration.Clear().AddEntityConfiguration(builder =>
                {
                    builder.UseInMemoryDatabase("DataDictionary");
                });

        }

        /// <summary>
        /// 通用初始化builder
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureExtraServices(this WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;
            IConfiguration configuration = builder.Configuration;
            //确保 .NET 运行时启用完整的全局化功能。
            Environment.SetEnvironmentVariable("DOTNET_SYSTEM_GLOBALIZATION_INVARIANT", "false");
            #region ServiceInjection 其他项目的Service注入
            services.AddServiceAutoDiscover();
            #endregion
            #region MassTransit 启用
            // Add services to the container.
            builder.Services.AddMassTransit(x =>
            {

                // 通过扫描程序集注册消费者
                var ass = DependencyContext.Default!.CompileLibraries
                .Where(l => !l.Serviceable && l.Type != "package" && l.Type == "project")
                .Select(l => Assembly.Load(new AssemblyName(l.Name)).GetTypes().Where(t => typeof(IConsumer).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract))
                .SelectMany(a => a).ToArray();
                x.AddConsumers(ass);

                x.UsingRabbitMq((context, config) =>
                {

                    config.Host("rabbitmq://18.183.85.117:5672", hostconfig =>
                    {
                        hostconfig.Username("admin");
                        hostconfig.Password("ji123486.*");
                    });

                    config.ConfigureEndpoints(context);

                });
            });
            #endregion
            #region JWT 验证
            //开始:Authentication,Authorization
            //只要需要校验Authentication报文头的地方（非IdentityService.WebAPI项目）也需要启用这些
            //IdentityService项目还需要启用AddIdentityCore
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication();

            //builder.Services.Configure<JWTOptions>(configuration.GetSection("JWTOptions"));
            builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JWTOptions"));
            JWTOptions jwtOpt = configuration.GetSection("JWTOptions").Get<JWTOptions>()!;



            //using IHost host = builder.Build();
            //JWTOptions options = host.Services.GetRequiredService<IOptions<JWTOptions>>().Value;
            //Console.WriteLine($"DisplayLabel={options.DisplayLabel}");
            //Console.WriteLine($"EndpointId={options.EndpointId}");
            //Console.WriteLine($"WidgetRoute={options.WidgetRoute}");



            //JWTOptions jwtOpt = (JWTOptions)configuration.GetSection("JWTOptions"); //暂时用Appsettings.json中的配置
            builder.Services.AddJWTAuthentication(jwtOpt);

            #endregion


            #region 跨域
            // 跨域
            //services.AddCors(options =>
            //{
            //    //更好的在Program.cs中用绑定方式读取配置的方法：https://github.com/dotnet/aspnetcore/issues/21491
            //    //不过比较麻烦。
            //    var corsOpt = configuration.GetSection("Cors").Get<CorsSettings>();
            //    string[] urls = corsOpt.Origins;
            //    options.AddDefaultPolicy(builder => builder.WithOrigins(urls)
            //            .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            //}

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("any", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });
            #endregion

            #region Swagger
            //启用Swagger中的【Authorize】按钮。这样就不用每个项目的AddSwaggerGen中单独配置了

            builder.Services.Configure<SwaggerGenOptions>(c =>
            {
                c.AddAuthenticationHeader();
            });
            //结束:Authentication,Authorization


            #endregion
        }


    }
}
