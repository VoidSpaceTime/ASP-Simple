using CommonsInitializer;
using FileServiceInfrastructure;
using FileServiceInfrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region 自定义初始化
//配置数据库
builder.ConfigureDbConfiguration();
//各类扩展配置
builder.ConfigureExtraServices();


// 配置注入
// 可通过依赖注入 private readonly MinioConfigurationOptions minioOptions; 获取配置
builder.Services.Configure<MinioStorageOptions>(builder.Configuration.GetSection("MinioStorageOptions"));
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// 获取强类型配置
//MinioConfigurationOptions configOpt = new("");
//app.Configuration.GetSection(nameof(MinioConfigurationOptions))
//    .Bind(configOpt);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
