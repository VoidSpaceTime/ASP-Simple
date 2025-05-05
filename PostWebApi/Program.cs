using CommonsInitializer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks; // ��Ӵ������ռ�  
using Microsoft.Extensions.DependencyInjection; // ��Ӵ������ռ�  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
#region �Զ����ʼ��  
// �������ݿ�  
builder.ConfigureDbConfiguration();
// ������չ����  
builder.ConfigureExtraServices();

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ��ӽ���������  
builder.Services.AddHealthChecks();

var app = builder.Build();

// ���ý�������м��  
//app.MapHealthChecks("/health");
app.UseStaticFiles();
app.UseHealthChecks("/health");
// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // ����ʱ ע�͵�HTTPS�ض����м��

app.UseAuthorization();

app.MapControllers();
app.UseCors("any");

app.Run();
