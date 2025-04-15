using CommonsInitializer;
using FileServiceInfrastructure;
using FileServiceInfrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region �Զ����ʼ��
//�������ݿ�
builder.ConfigureDbConfiguration();
//������չ����
builder.ConfigureExtraServices();


// ����ע��
// ��ͨ������ע�� private readonly MinioConfigurationOptions minioOptions; ��ȡ����
builder.Services.Configure<MinioStorageOptions>(builder.Configuration.GetSection("MinioStorageOptions"));
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// ��ȡǿ��������
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
