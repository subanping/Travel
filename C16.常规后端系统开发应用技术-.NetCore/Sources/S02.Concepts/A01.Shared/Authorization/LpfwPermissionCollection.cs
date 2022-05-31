namespace WebApiConcepts.A01.Shared.Authorization
{
    /// <summary>
    /// 定制的访问许可授权条目集合
    /// </summary>
    public class LpfwPermissionCollection
    {
        private static readonly LpfwPermission[] _all = new LpfwPermission[]
        {
            new("View Base", LpfwAction.View, LpfwResource.Base, IsBasic: true),
            new("Search Base", LpfwAction.Search, LpfwResource.Base, IsBasic: true),
            new("Create Base", LpfwAction.Create, LpfwResource.Base),
            new("Update Base", LpfwAction.Update, LpfwResource.Base),
            new("Delete Base", LpfwAction.Delete, LpfwResource.Base),
            new("Generate Base", LpfwAction.Generate, LpfwResource.Base),
            new("Clean Base", LpfwAction.Clean, LpfwResource.Base),

            new("View ApplicationUsers", LpfwAction.View, LpfwResource.ApplicationUsers),
            new("Search ApplicationUsers", LpfwAction.Search, LpfwResource.ApplicationUsers),
            new("Create ApplicationUsers", LpfwAction.Create, LpfwResource.ApplicationUsers),
            new("Update ApplicationUsers", LpfwAction.Update, LpfwResource.ApplicationUsers),
            new("Delete ApplicationUsers", LpfwAction.Delete, LpfwResource.ApplicationUsers),
            new("Export ApplicationUsers", LpfwAction.Export, LpfwResource.ApplicationUsers),

            new("View ApplicationUserRoles", LpfwAction.View, LpfwResource.ApplicationUserRoles),
            new("Update ApplicationUserRoles", LpfwAction.Update, LpfwResource.ApplicationUserRoles),

            new("View ApplicationRoles", LpfwAction.View, LpfwResource.ApplicationRoles),
            new("Create ApplicationRoles", LpfwAction.Create, LpfwResource.ApplicationRoles),
            new("Update ApplicationRoles", LpfwAction.Update, LpfwResource.ApplicationRoles),
            new("Delete ApplicationRoles", LpfwAction.Delete, LpfwResource.ApplicationRoles),

            new("View ApplicationRoleClaims", LpfwAction.View, LpfwResource.ApplicationRoleClaims),
            new("Update ApplicationRoleClaims", LpfwAction.Update, LpfwResource.ApplicationRoleClaims),

            new("View TeachClasses", LpfwAction.View, LpfwResource.TeachClasses, IsBasic: true),
            new("Search TeachClasses", LpfwAction.Search, LpfwResource.TeachClasses, IsBasic: true),
            new("Create TeachClasses", LpfwAction.Create, LpfwResource.TeachClasses),
            new("Update TeachClasses", LpfwAction.Update, LpfwResource.TeachClasses),
            new("Delete TeachClasses", LpfwAction.Delete, LpfwResource.TeachClasses),
            new("Export TeachClasses", LpfwAction.Export, LpfwResource.TeachClasses),

            new("View Students", LpfwAction.View, LpfwResource.Students, IsBasic: true),
            new("Search Students", LpfwAction.Search, LpfwResource.Students, IsBasic: true),
            new("Create Students", LpfwAction.Create, LpfwResource.Students),
            new("Update Students", LpfwAction.Update, LpfwResource.Students),
            new("Delete Students", LpfwAction.Delete, LpfwResource.Students),
            new("Generate Students", LpfwAction.Generate, LpfwResource.Students),
            new("Clean Students", LpfwAction.Clean, LpfwResource.Students),

            new("View Tenants", LpfwAction.View, LpfwResource.Tenants, IsRoot: true),
            new("Create Tenants", LpfwAction.Create, LpfwResource.Tenants, IsRoot: true),
            new("Update Tenants", LpfwAction.Update, LpfwResource.Tenants, IsRoot: true),
            new("Upgrade Tenant Subscription", LpfwAction.UpgradeSubscription, LpfwResource.Tenants, IsRoot: true)
        };

        /// <summary>
        /// 所有资源访问权限权限
        /// </summary>
        public static IReadOnlyList<LpfwPermission> All { get; } = new ReadOnlyCollection<LpfwPermission>(_all);
        /// <summary>
        /// 根资源访问许可
        /// </summary>
        public static IReadOnlyList<LpfwPermission> Root { get; } = new ReadOnlyCollection<LpfwPermission>
            (_all.Where(p => p.IsRoot).ToArray());
        /// <summary>
        /// 归属于 Admin 业务组的许可权限
        /// </summary>
        public static IReadOnlyList<LpfwPermission> Admin { get; } = new ReadOnlyCollection<LpfwPermission>
            (_all.Where(p => !p.IsRoot).ToArray());
        /// <summary>
        /// 归属于普通业务组的访问许可权限
        /// </summary>
        public static IReadOnlyList<LpfwPermission> Basic { get; } = new ReadOnlyCollection<LpfwPermission>
            (_all.Where(p => p.IsBasic).ToArray());
    }
}
