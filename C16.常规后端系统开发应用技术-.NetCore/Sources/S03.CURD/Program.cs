using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using DataCURD.B05.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// 日志提供程序
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// 使用 Sql Server
var connectionString = builder.Configuration.GetConnectionString("lpfwDbConnection");
builder.Services.AddDbContext<DomainDataDbContext>(options =>
    options.UseSqlServer(connectionString));

// 使用内存数据库
//builder.Services.AddDbContext<DomainDataDbContext>(options =>
//    options.UseInMemoryDatabase("MemoryDB"));

// 添加 Asp.Net Core Identity 服务 
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<DomainDataDbContext>()
                .AddDefaultTokenProviders();
// 依赖注入配置
builder.Services.DataDependencyInjector();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// 为 Swwager 文档器，添加 jwt 认证处理
builder.Services.AddSwaggerGen(c =>
{
    // 添加Jwt验证设置,添加请求头信息
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });

    // 添加接口文档 Auth授权按钮及其相关的说明
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "在获取token之后，使用 Bearer+空格+{token}，填入下面的输入框中！", 
        Name = "Authorization",       //jwt默认的参数名称
        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey
    });
});

// 添加 JWT 服务，用于为前端用户建立用户 token 的连接
builder.Services.Configure<ApplicationUserJWTSetting>(builder.Configuration.GetSection("JwtSetting"));
var jwtSetting = new ApplicationUserJWTSetting();
builder.Configuration.Bind("JwtSetting", jwtSetting);
builder.Services.AddAuthentication(option =>{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtSetting.Issuer,
            ValidAudience = jwtSetting.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecretKey!))
        };
    });

var app = builder.Build();

// 调用 种子数据初始化数据库数据的服务
await app.Services.InitializeDatabasesAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 加载跨域访问中间件
app.UseCors(option => option
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

app.UseHttpsRedirection();

// 加载身份认证中间件
app.UseAuthentication();

// 加载授权管理中间件
app.UseAuthorization();

// 加载根据 http 上下文，使用当前访问中的持证人数据，初始化当前访问的用户数据，定制的中间件
app.UseMiddleware<CurrentUserMiddleware>();

// 默认路由 “/” 
app.MapControllers();

app.Run();
