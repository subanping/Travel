namespace WebApiStartup.ServiceProviderHelpers
{
    public static class ServiceProviderHelper
    {
        /// <summary>
        /// 初始化数据库数据，通过 IServiceProvider 扩展方法实现
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static async Task InitializeDatabasesAsync(this IServiceProvider services)
        {
            // 创建一个定制的 scope
            using var scope = services.CreateScope();
            // 在这个 scope 内的服务供应者添加 IData 接口的 Initial() 方法执行初始化数据
            await scope.ServiceProvider.GetRequiredService<IDataSeed>().Initial();
        }
    }
}
