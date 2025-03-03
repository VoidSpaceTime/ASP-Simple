using CommonsDomain.Entities;
using CommonsInitializer;
using DbConfigurationProvider;
using IdentityServiceDomain.Entities;
using IdentityServiceInfrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureDbConfiguration();
//builder.ConfigureExtraServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataProtection();


//builder.Services.AddScoped<IdDomainService>();
//builder.Services.AddScoped<IIdRepository, IdRepository>();
//builder.Services.AddScoped<ITokenService, TokenService>();





#region Identity 验证
//登录、注册的项目除了要启用WebApplicationBuilderExtensions中的初始化之外，还要如下的初始化
//不要用AddIdentity，而是用AddIdentityCore
//因为用AddIdentity会导致JWT机制不起作用，AddJwtBearer中回调不会被执行，因此总是Authentication校验失败
//https://github.com/aspnet/Identity/issues/1376
IdentityBuilder idBuilder = builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    //不能设定RequireUniqueEmail，否则不允许邮箱为空
    //options.User.RequireUniqueEmail = true;
    //以下两行，把GenerateEmailConfirmationTokenAsync验证码缩短
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
}
);
idBuilder = new IdentityBuilder(idBuilder.UserType, typeof(Role), builder.Services);
idBuilder.AddEntityFrameworkStores<IdDbContext>().AddDefaultTokenProviders()
    //.AddRoleValidator<RoleValidator<Role>>()
    .AddRoleManager<RoleManager<Role>>()
    .AddUserManager<IdUserManager>();

//Database
builder.Services.AddDbContext<IdDbContext>(ctx =>
{
    string connStr = Environment.GetEnvironmentVariable("ASPSimpleDB:ConnStr");
    ctx.UseSqlServer(connStr);
});
#endregion

var app = builder.Build();

//Config options = app.Services.GetRequiredService<IOptions<Config>>().Value;

//Config options = app.Services.GetRequiredService<IOptions<Config>>().Value;
//Console.WriteLine($"DisplayLabel={options.DisplayLabel}");
//Console.WriteLine($"EndpointId={options.EndpointId}");

Console.WriteLine($"-----------------------------------------");


var configuration = app.Services.GetService<IConfiguration>();
var ts1 = configuration.GetValue<string>("WidgetOptions:EndpointId");
var ts2 = configuration.GetValue<string>("WidgetOptions:DisplayLabel");
var ts3 = configuration.GetValue<string>("WidgetOptions:JWTOptions");
var ts4 = configuration.GetValue<string>("JWTOptions");
Console.WriteLine($"idgetOptions:EndpointId: {configuration.GetValue<string>("idgetOptions:EndpointId")}");
Console.WriteLine($"WidgetOptions:DisplayLabel: {configuration.GetValue<string>("WidgetOptions:DisplayLabel")}");

//["WidgetOptions:EndpointId"] = "b3da3c4c-9c4e-4411-bc4d-609e2dcc5c67",
//                ["WidgetOptions:DisplayLabel"] = "Widgets Incorporated, LLC.",
//                ["WidgetOptions:WidgetRoute"] = "api/widgets"


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("any");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



