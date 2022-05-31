namespace DataCURD.A01.Shared.Authorization
{
    /// <summary>
    /// 资源访问许可
    /// </summary>
    /// <param name="Description">说明</param>
    /// <param name="Action">数据处理操作方式</param>
    /// <param name="Resource">数据资源</param>
    /// <param name="IsBasic">是否是基本权限</param>
    /// <param name="IsRoot">是否是根权限</param>
    public record LpfwPermission(
        string Description, 
        string Action, 
        string Resource, 
        bool IsBasic = false,
        bool IsRoot = false)
    {
        /// <summary>
        /// 许可名称（许可中的授权策略）
        /// </summary>
        public string Name => NameFor(Action, Resource);

        /// <summary>
        /// 根据数字资源和数据处理操作方式，获取对应的授权策略
        /// </summary>
        /// <param name="action"></param>
        /// <param name="resource">数字资源</param>
        /// <returns></returns>
        public static string NameFor(string action, string resource) => 
            $"Permissions.{resource}.{action}";
    }
}
