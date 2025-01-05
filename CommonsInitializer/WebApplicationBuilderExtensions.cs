using JWTCommons;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Data.SqlClient;

namespace CommonsInitializer
{
    //public static class WebApplicationBuilderExtensions
    //{
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


    //    public static void ConfigureExtraServices(this WebApplicationBuilder builder)
    //    {
    //        IServiceCollection services = builder.Services;
    //        IConfiguration configuration = builder.Configuration;
    //        //var assemblies = ReflectionHelper.GetAllReferencedAssemblies();
    //        //services.RunModuleInitializers(assemblies);
    //        services.AddDbContextFactory<DbContextOptionsBuilderFactory>(ctx =>
    //        {
    //            //连接字符串如果放到appsettings.json中，会有泄密的风险
    //            //如果放到UserSecrets中，每个项目都要配置，很麻烦
    //            //因此这里推荐放到环境变量中。
    //            string connStr = configuration.GetValue<string>("DefaultDB:ConnStr");
    //            ctx.UseSqlServer(connStr);
    //        });

    //        //开始:Authentication,Authorization
    //        //只要需要校验Authentication报文头的地方（非IdentityService.WebAPI项目）也需要启用这些
    //        //IdentityService项目还需要启用AddIdentityCore
    //        builder.Services.AddAuthorization();
    //        builder.Services.AddAuthentication();
    //        JWTOptions jwtOpt = configuration.GetSection("JWT").Get<JWTOptions>();
    //        builder.Services.AddJWTAuthentication(jwtOpt);
    //        //启用Swagger中的【Authorize】按钮。这样就不用每个项目的AddSwaggerGen中单独配置了
    //        builder.Services.Configure<SwaggerGenOptions>(c =>
    //        {
    //            c.AddAuthenticationHeader();
    //        });
    //        //结束:Authentication,Authorization
    //    }
    //}
}
