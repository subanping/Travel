namespace DataCURD.B04.Permissions
{
    /// <summary>
    /// 当前用户信息处理接口定义
    /// </summary>
    public interface ICurrentUser
    {
        /// <summary>
        /// 用户名
        /// </summary>
        string? Name { get; }
        /// <summary>
        /// 提取用户 Id
        /// </summary>
        /// <returns></returns>
        Guid GetUserId();
        /// <summary>
        /// 提取用户电子邮件
        /// </summary>
        /// <returns></returns>
        string? GetUserEmail();
        /// <summary>
        /// 提取用户的租户
        /// </summary>
        /// <returns></returns>
        string? GetTenant();
        /// <summary>
        /// 是否已经认证
        /// </summary>
        /// <returns></returns>
        bool IsAuthenticated();
        /// <summary>
        /// 是否归属某些角色组
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        bool IsInRole(string role);
        /// <summary>
        /// 提取用户的 Claim 集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<Claim>? GetUserClaims();
    }
}
