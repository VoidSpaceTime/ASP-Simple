using CommonsInitializer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks; // 添加此命名空间  
using Microsoft.Extensions.DependencyInjection; // 添加此命名空间  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
#region 自定义初始化  
// 配置数据库  
builder.ConfigureDbConfiguration();
// 各类扩展配置  
builder.ConfigureExtraServices();

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 添加健康检查服务  
builder.Services.AddHealthChecks();

var app = builder.Build();

// 配置健康检查中间件  
//app.MapHealthChecks("/health");
app.UseStaticFiles();
app.UseHealthChecks("/health");
// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // 发布时 注释掉HTTPS重定向中间件

app.UseAuthorization();

app.MapControllers();
app.UseCors("any");

app.Run();
