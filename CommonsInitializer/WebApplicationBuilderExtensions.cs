using Commons;
using DbConfigurationProvider;
using JWT;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using Infrastructure;
using Infrastructure.EFCore;
using DbConfigurationProvider.EntityConfigurations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore;

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
            IServiceCollection services = builder.Services;

            /*          // 清除原有的配置提供程序
                      builder.Configuration.Sources.Clear();

                      builder.Configuration.AddEntityConfiguration(options =>
                      {
                          //options.UseSqlServer("Server=10.60.71.213;Uid=sa;Pwd=mssql_wpxJsp;Database=DefaultConfigDB;Trusted_Connection=False;MultipleActiveResultSets=True;Encrypt=true;TrustServerCertificate=true;");
                          options.UseInMemoryDatabase("DataDictionary");
                      });*/
            // 微软方案
            //builder.Configuration.Sources.Clear();
            builder.Configuration.AddEntityConfiguration();
            // 注入到服务中
            services.Configure<EntityConfigurationOptions>(
                   builder.Configuration.GetSection(nameof(EntityConfigurationOptions)));
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
            #region 获取配置数据库配置
            // 绑定到对象 在当前代码中使用
            EntityConfigurationOptions configOpt = new();
            builder.Configuration.GetSection(nameof(EntityConfigurationOptions))
                .Bind(configOpt);


            #endregion
            #region 注入全部数据库
            var assemblies = ReflectionHelper.GetAllcompiledAssemblies();

            services.AddAllDbContexts(ctx =>
            {
                string? connStr = configOpt.ASPSimpleDB;
                if (connStr != null)
                    ctx.UseSqlServer(connStr);
                else
                {
                    throw new Exception($"未配置数据库链接字符串:{nameof(ctx)}");
                }
            }, assemblies);

            #endregion
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

                    config.Host($"rabbitmq://{configOpt.RabbitMQConnection.HostName}", hostconfig =>
                    {
                        hostconfig.Username(configOpt.RabbitMQConnection.UserName);
                        hostconfig.Password(configOpt.RabbitMQConnection.Password);
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

            //JWTOptions jwtOpt = configuration.Get<JWTOptions>()!;
            //JWTOptions jwtOpt = configuration.Get<JWTOptions>()!;
            //JWTOptions jwtOpt = builder.Configuration.GetSection(nameof(JWTOptions));
            builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("EntityConfigurationOptions:JWTOptions"));
            builder.Services.AddJWTAuthentication(configOpt.JWTOptions);

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
            #region UnitOfWork
            //现在不用手动AddMVC了，因此把文档中的services.AddMvc(options =>{})改写成Configure<MvcOptions>(options=> {})这个问题很多都类似
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add<UnitOfWorkFilter>();
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
