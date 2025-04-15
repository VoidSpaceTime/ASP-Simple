using CommonsInitializer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region 自定义初始化
//配置数据库
builder.ConfigureDbConfiguration();
//各类扩展配置
builder.ConfigureExtraServices();

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("any");

app.Run();
