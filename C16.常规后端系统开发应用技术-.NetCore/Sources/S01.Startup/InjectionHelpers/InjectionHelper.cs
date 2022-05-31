namespace WebApiStartup.InjectionHelpers
{
    public static class InjectionHelper
    {
        /// <summary>
        /// 用于配置数据注入配置器 IServiceCollection 的扩展
        /// </summary>
        /// <param name="services"></param>
        public static void DataDependencyInjector(this IServiceCollection services)
        {
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
        }

        /// <summary>
        /// 系统业务数据处理部分
        /// </summary>
        /// <param name="services"></param>
        static void _ForApplicationBusiness(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentDtoService, StudentDtoService>();
            services.AddScoped<IStudentRequestService, StudentRequestService>();

            services.AddScoped<ITeachClassRepository, TeachClassRepository>();
            services.AddScoped<ITeachClassDtoService, TeachClassDtoService>();
            services.AddScoped<ITeachClassRequestService, TeachClassRequestService>();
        }

    }
}
