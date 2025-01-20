using Commons;
using JWT;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CommonsInitializer
{
    public static class WebApplicationBuilderExtensions
    {
        //    /// <summary>
        //    /// 配置数据库连接字符串可热更
        //    /// </summary>
        //    /// <param name="builder"></param>
        //    public static void ConfigureDbConfiguration(this WebApplicationBuilder builder)
        //    {
        //        builder.Host.ConfigureAppConfiguration((hostCtx, configBuilder) =>
        //        {
        //            //不能使用ConfigureAppConfiguration中的configBuilder去读取配置，否则就循环调用了，因此这里直接自己去读取配置文件
        //            //var configRoot = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        //            //string connStr = configRoot.GetValue<string>("DefaultDB:ConnStr");
        //            string connStr = builder.Configuration.GetValue<string>("DefaultDB:ConnStr");
        //            configBuilder.AddConfiguration(new SqlConnection(connStr));
        //        });
        //    }
        //}

        /// <summary>
        /// 通用初始化builder
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureExtraServices(this WebApplicationBuilder builder)
        {
            IServiceCollection services = builder.Services;
            IConfiguration configuration = builder.Configuration;

            Environment.SetEnvironmentVariable("DOTNET_SYSTEM_GLOBALIZATION_INVARIANT", "false");
            #region ServiceInjection 其他项目的Service注入
            services.AddServiceAutoDiscover();
            #endregion
            #region MassTransit 启用
            // Add services to the container.
            builder.Services.AddMassTransit(x =>
            {

                // 通过扫描程序集注册消费者
                var ass = DependencyContext.Default.CompileLibraries
                .Where(l => !l.Serviceable && l.Type != "package" && l.Type == "project")
                .Select(l => Assembly.Load(new AssemblyName(l.Name)).GetTypes().Where(t => typeof(IConsumer).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract))
                .SelectMany(a => a).ToArray();
                //x.AddConsumers(AppDomain.CurrentDomain.GetAssemblies());
                x.AddConsumers(ass);

                // 通过类型单个注册消费者
                //x.AddConsumer<UserConsumer>();

                // x.SetKebabCaseEndpointNameFormatter();

                // 通过泛型单个注册消费者
                //x.AddConsumer<OrderEtoConsumer, OrderEtoConsumerDefinition>();

                // 通过指定命名空间注册消费者
                // x.AddConsumersFromNamespaceContaining<OrderEtoConsumer>();
                // 内存
                //x.SetInMemorySagaRepositoryProvider();

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

            JWTOptions jwtOpt = configuration.GetSection("JWTOptions").Get<JWTOptions>();
            builder.Services.Configure<JWTOptions>(configuration.GetSection("JWTOptions"));

            //builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("JWTOptions"));
            //JWTOptions jwtOpt = (JWTOptions)configuration.GetSection("JWTOptions"); //暂时用Appsettings.json中的配置
            builder.Services.AddJWTAuthentication(jwtOpt);

            #endregion
            //启用Swagger中的【Authorize】按钮。这样就不用每个项目的AddSwaggerGen中单独配置了
            builder.Services.Configure<SwaggerGenOptions>(c =>
            {
                c.AddAuthenticationHeader();
            });
            //结束:Authentication,Authorization


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
        }

    }
}
