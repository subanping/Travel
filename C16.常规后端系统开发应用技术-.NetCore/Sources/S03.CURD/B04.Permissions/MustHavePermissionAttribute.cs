namespace DataCURD.B04.Permissions
{
    /// <summary>
    /// 自定义的 “必须经过许可” 特性，用于限制控制器方法的授权
    /// </summary>
    public class MustHavePermissionAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="action">数据处理操作方式</param>
        /// <param name="resource">数字资源</param>
        public MustHavePermissionAttribute(string action, string resource) =>
            // 添加授权策略
            Policy = LpfwPermission.NameFor(action, resource);
    }
}
