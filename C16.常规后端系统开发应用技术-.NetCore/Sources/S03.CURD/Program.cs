using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using DataCURD.B05.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// ��־�ṩ����
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// ʹ�� Sql Server
var connectionString = builder.Configuration.GetConnectionString("lpfwDbConnection");
builder.Services.AddDbContext<DomainDataDbContext>(options =>
    options.UseSqlServer(connectionString));

// ʹ���ڴ����ݿ�
//builder.Services.AddDbContext<DomainDataDbContext>(options =>
//    options.UseInMemoryDatabase("MemoryDB"));

// ��� Asp.Net Core Identity ���� 
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
// ����ע������
builder.Services.DataDependencyInjector();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Ϊ Swwager �ĵ�������� jwt ��֤����
builder.Services.AddSwaggerGen(c =>
{
    // ���Jwt��֤����,�������ͷ��Ϣ
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

    // ��ӽӿ��ĵ� Auth��Ȩ��ť������ص�˵��
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "�ڻ�ȡtoken֮��ʹ�� Bearer+�ո�+{token}�����������������У�", 
        Name = "Authorization",       //jwtĬ�ϵĲ�������
        In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
        Type = SecuritySchemeType.ApiKey
    });
});

// ��� JWT ��������Ϊǰ���û������û� token ������
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

// ���� �������ݳ�ʼ�����ݿ����ݵķ���
await app.Services.InitializeDatabasesAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ���ؿ�������м��
app.UseCors(option => option
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());

app.UseHttpsRedirection();

// ���������֤�м��
app.UseAuthentication();

// ������Ȩ�����м��
app.UseAuthorization();

// ���ظ��� http �����ģ�ʹ�õ�ǰ�����еĳ�֤�����ݣ���ʼ����ǰ���ʵ��û����ݣ����Ƶ��м��
app.UseMiddleware<CurrentUserMiddleware>();

// Ĭ��·�� ��/�� 
app.MapControllers();

app.Run();
