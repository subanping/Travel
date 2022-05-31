using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApiStartup.InjectionHelpers;
using WebApiStartup.ServiceProviderHelpers;

// 定义 app 构建器
var builder = WebApplication.CreateBuilder(args);

// 使用内存数据库
builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase("MemoryDB"));

// 依赖注入配置
builder.Services.DataDependencyInjector();

// 配入控制器
builder.Services.AddControllers().AddNewtonsoftJson();

// 需要学习 Swagger/OpenAPI 的话，请参考： https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Web API 开发设计服务接口文档",
        Description = "这是用于说明后台服务接口的具体内容。",
        
        // 服务说明（通常是说明服务支持的期限）
        //TermsOfService = new Uri("https://example.com/terms"),
        
        // 联系信息
        //Contact = new OpenApiContact
        //{
        //    Name = "Example Contact",
        //    Url = new Uri("https://example.com/contact")
        //},

        // 使用许可信息
        //License = new OpenApiLicense
        //{
        //    Name = "Example License",
        //    Url = new Uri("https://example.com/license")
        //}
    });

    // 直接利用反射获取 WebApiStartup.xml 用于承载相关文件的解析
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// 构建
var app = builder.Build();

// 初始化种子数据
await app.Services.InitializeDatabasesAsync();

// 定义开发环境中需要的中间件
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 该中间件配置跨域访问
app.UseCors(option => option
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

// 使用该中间件以允许 http 访问可自动定向到 https
app.UseHttpsRedirection();

// 使用该中间件以允许处理访问授权
app.UseAuthorization();

app.MapControllers();

app.Run();
