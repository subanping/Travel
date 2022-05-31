namespace WebApiConcepts.B04.Permissions
{
    /// <summary>
    /// 系统当前用户初始化接口定义
    /// </summary>
    public interface ICurrentUserInitializer
    {
        /// <summary>
        /// 根据当前访问的持证人的数据，设置当前用户信息
        /// </summary>
        /// <param name="user"></param>
        void SetCurrentUser(ClaimsPrincipal user);
        /// <summary>
        /// 根据用户 Id 设置当前用户的 Id
        /// </summary>
        /// <param name="userId"></param>
        void SetCurrentUserId(string userId);
    }
}
