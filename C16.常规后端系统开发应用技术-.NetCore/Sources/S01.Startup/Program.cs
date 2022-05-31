using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApiStartup.InjectionHelpers;
using WebApiStartup.ServiceProviderHelpers;

// ���� app ������
var builder = WebApplication.CreateBuilder(args);

// ʹ���ڴ����ݿ�
builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase("MemoryDB"));

// ����ע������
builder.Services.DataDependencyInjector();

// ���������
builder.Services.AddControllers().AddNewtonsoftJson();

// ��Ҫѧϰ Swagger/OpenAPI �Ļ�����ο��� https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Web API ������Ʒ���ӿ��ĵ�",
        Description = "��������˵����̨����ӿڵľ������ݡ�",
        
        // ����˵����ͨ����˵������֧�ֵ����ޣ�
        //TermsOfService = new Uri("https://example.com/terms"),
        
        // ��ϵ��Ϣ
        //Contact = new OpenApiContact
        //{
        //    Name = "Example Contact",
        //    Url = new Uri("https://example.com/contact")
        //},

        // ʹ�������Ϣ
        //License = new OpenApiLicense
        //{
        //    Name = "Example License",
        //    Url = new Uri("https://example.com/license")
        //}
    });

    // ֱ�����÷����ȡ WebApiStartup.xml ���ڳ�������ļ��Ľ���
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// ����
var app = builder.Build();

// ��ʼ����������
await app.Services.InitializeDatabasesAsync();

// ���忪����������Ҫ���м��
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ���м�����ÿ������
app.UseCors(option => option
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

// ʹ�ø��м�������� http ���ʿ��Զ����� https
app.UseHttpsRedirection();

// ʹ�ø��м���������������Ȩ
app.UseAuthorization();

app.MapControllers();

app.Run();
