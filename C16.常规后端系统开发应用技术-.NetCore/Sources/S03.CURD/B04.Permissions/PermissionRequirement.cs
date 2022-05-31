namespace DataCURD.B04.Permissions
{
    /// <summary>
    /// 授权需求
    /// </summary>
    internal class PermissionRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// 授权许可名策略名称
        /// </summary>
        public string Permission { get; private set; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
