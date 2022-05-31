namespace DataCURD.A01.Shared.Authorization
{
    /// <summary>
    /// 处理用户登录令牌声明主体（持证人）的扩展方法
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// 获取其中的电子邮件
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string? GetEmail(this ClaimsPrincipal principal)
            => principal.FindFirstValue(ClaimTypes.Email);

        /// <summary>
        /// 获取其中的租户
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string? GetTenant(this ClaimsPrincipal principal)
            => principal.FindFirstValue(LpfwClaims.Tenant);

        /// <summary>
        /// 获取全名
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string? GetFullName(this ClaimsPrincipal principal)
            => principal?.FindFirst(LpfwClaims.Fullname)?.Value;

        /// <summary>
        /// 获取名字
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string? GetFirstName(this ClaimsPrincipal principal)
            => principal?.FindFirst(ClaimTypes.Name)?.Value;

        /// <summary>
        /// 获取姓氏
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string? GetSurname(this ClaimsPrincipal principal)
            => principal?.FindFirst(ClaimTypes.Surname)?.Value;

        /// <summary>
        /// 获取移动电话
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string? GetPhoneNumber(this ClaimsPrincipal principal)
            => principal.FindFirstValue(ClaimTypes.MobilePhone);

        /// <summary>
        /// 获取用户 Id
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string? GetUserId(this ClaimsPrincipal principal)
           => principal.FindFirstValue(ClaimTypes.NameIdentifier);

        /// <summary>
        /// 获取用户头像地址
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string? GetImageUrl(this ClaimsPrincipal principal)
           => principal.FindFirstValue(LpfwClaims.ImageUrl);

        /// <summary>
        /// 获取证件有效期截止日期
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static DateTimeOffset GetExpiration(this ClaimsPrincipal principal) =>
            DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(
                principal.FindFirstValue(LpfwClaims.Expiration)));

        /// <summary>
        /// 查找 ClaimsPrincipal 指定类型的 Claim 的值
        /// </summary>
        /// <param name="principal"> Claim 主体</param>
        /// <param name="claimType"> Claim 类型</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private static string? FindFirstValue(this ClaimsPrincipal principal, string claimType) =>
            principal is null
                ? throw new ArgumentNullException(nameof(principal))
                : principal.FindFirst(claimType)?.Value;
    }
}
