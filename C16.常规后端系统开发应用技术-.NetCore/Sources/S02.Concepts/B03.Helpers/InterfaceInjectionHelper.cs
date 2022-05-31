using WebApiConcepts.A02._02.Domain.ORM.Seeds;
using WebApiConcepts.B05.Middlewares;

namespace WebApiConcepts.B03.Helpers
{
    public static class InterfaceInjectionHelper
    {
        /// <summary>
        /// 用于配置数据注入配置器 IServiceCollection 的扩展
        /// </summary>
        /// <param name="services"></param>
        public static void DataDependencyInjector(this IServiceCollection services)
        {
            services._ForPermissionAuthorization();
            services._ForApplication();
            services._ForApplicationBusiness();
        }

        /// <summary>
        /// 系统基础数据处理部分
        /// </summary>
        /// <param name="services"></param>
        static void _ForApplication(this IServiceCollection services)
        {
            // 种子数据
            services.AddScoped<IDataSeed, DataSeed>();
            // 系统用户
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDtoModelService, UserDtoModelService>();
            services.AddScoped<IUserRequestModelService, UserRequestModelService>();

        }

        /// <summary>
        /// 系统授权管理实现部分
        /// </summary>
        /// <param name="services"></param>
        static void _ForPermissionAuthorization(this IServiceCollection services)
        {
            services
                // 注册中间件
                .AddScoped<CurrentUserMiddleware>()   
                .AddScoped<ICurrentUser, CurrentUser>()
                .AddScoped(sp => (ICurrentUserInitializer)sp.GetRequiredService<ICurrentUser>());
            services
                // 将授权策略映射为定制的策略
                .AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
                // 将授权处理映射为定制的处理器
                .AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();       
        }

        /// <summary>
        /// 系统业务数据处理部分
        /// </summary>
        /// <param name="services"></param>
        static void _ForApplicationBusiness(this IServiceCollection services)
        {
            services.AddScoped<IDomainRepository<Student>, DomainRepository<Student>>();
            services.AddScoped<IDtoModelService<Student,StudentDto>, DtoModelService<Student, StudentDto>>();
            services.AddScoped<IRequestModelService<Student,StudentEditRequest>, RequestModelService<Student, StudentEditRequest>>();
            services.AddScoped<IRequestModelService<Student, StudentCreateRequest>, RequestModelService<Student, StudentCreateRequest>>();
            services.AddScoped<ISearchRequestService<Student, StudentSearchRequest>, SearchRequestService<Student, StudentSearchRequest>>();

            services.AddScoped<IDomainRepository<TeachClass>, DomainRepository<TeachClass>>();
            services.AddScoped<IDtoModelService<TeachClass, TeachClassDto>, DtoModelService<TeachClass, TeachClassDto>>();
            services.AddScoped<IRequestModelService<TeachClass, TeachClassEditRequest>, RequestModelService<TeachClass, TeachClassEditRequest>>();
            services.AddScoped<ISearchRequestService<TeachClass, SearchRequest>, SearchRequestService<TeachClass, SearchRequest>>();
  
            services.AddScoped<IDomainRepository<TeachClassRoom>, DomainRepository<TeachClassRoom>>();
            services.AddScoped<IDtoModelService<TeachClassRoom, TeachClassRoomDto>, DtoModelService<TeachClassRoom, TeachClassRoomDto>>();
            services.AddScoped<IRequestModelService<TeachClassRoom, TeachClassRoomRequest>, RequestModelService<TeachClassRoom, TeachClassRoomRequest>>();
            services.AddScoped<ISearchRequestService<TeachClassRoom, SearchRequest>, SearchRequestService<TeachClassRoom, SearchRequest>>();
        }
    }
}
