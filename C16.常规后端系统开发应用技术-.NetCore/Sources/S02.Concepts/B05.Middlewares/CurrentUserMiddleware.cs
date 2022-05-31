using WebApiConcepts.B04.Permissions;

namespace WebApiConcepts.B05.Middlewares
{
    /// <summary>
    /// 当前访问用户用户设置中间件，负责拦截每次的访问，获取 http 访问上下文中的持证人数据以便初始化
    ///    当前访问中的用户数据。
    /// </summary>
    public class CurrentUserMiddleware : IMiddleware
    {
        /// <summary>
        /// 当前访问中用户初始化处理接口
        /// </summary>
        private readonly ICurrentUserInitializer _currentUserInitializer;

        public CurrentUserMiddleware(ICurrentUserInitializer currentUserInitializer) =>
            _currentUserInitializer = currentUserInitializer;

        /// <summary>
        /// 拦截执行程序
        /// </summary>
        /// <param name="context"> http 上下文</param>
        /// <param name="next">请求委托</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // 初始化当前访问的用户数据
            _currentUserInitializer.SetCurrentUser(context.User);
            // 完成后继续
            await next(context);
        }
    }
}
