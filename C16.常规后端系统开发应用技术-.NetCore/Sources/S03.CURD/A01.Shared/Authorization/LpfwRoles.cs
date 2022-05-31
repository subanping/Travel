namespace DataCURD.A01.Shared.Authorization
{
    /// <summary>
    /// 用于处理授权服务的角色组定义
    /// </summary>
    public static class LpfwRoles
    {
        public const string Admin = nameof(Admin);
        public const string Basic = nameof(Basic);

        public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
        {
            Admin,
            Basic
        });

        public static bool IsDefault(string roleName) => DefaultRoles.Any(r => r == roleName);
    }
}
