namespace WebApiConcepts.A01.Shared.Authorization
{
    /// <summary>
    /// 自定义的登录令牌声明的名称
    /// </summary>
    public static class LpfwClaims
    {
        /// <summary>
        /// 系统租户
        /// </summary>
        public const string Tenant = "tenant";
        /// <summary>
        /// 系统租户的全称
        /// </summary>
        public const string Fullname = "fullName";
        /// <summary>
        /// 许可
        /// </summary>
        public const string Permission = "permission";
        /// <summary>
        /// 图片（头像）路径
        /// </summary>
        public const string ImageUrl = "image_url";
        /// <summary>
        /// 客户端的 Ip 地址
        /// </summary>
        public const string IpAddress = "ipAddress";
        /// <summary>
        /// 过期信息
        /// </summary>
        public const string Expiration = "exp";
    }
}
