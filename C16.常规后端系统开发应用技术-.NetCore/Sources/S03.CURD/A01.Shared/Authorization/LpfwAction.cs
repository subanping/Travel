namespace DataCURD.A01.Shared.Authorization
{
    /// <summary>
    /// 定义数据处理操作方式的基础定义
    /// </summary>
    public static class LpfwAction
    {
        /// <summary>
        /// 查看
        /// </summary>
        public const string View = nameof(View);
        /// <summary>
        /// 检索
        /// </summary>
        public const string Search = nameof(Search);
        /// <summary>
        /// 新增
        /// </summary>
        public const string Create = nameof(Create);
        /// <summary>
        /// 更新
        /// </summary>
        public const string Update = nameof(Update);
        /// <summary>
        /// 删除
        /// </summary>
        public const string Delete = nameof(Delete);
        /// <summary>
        /// 导出
        /// </summary>
        public const string Export = nameof(Export);
        /// <summary>
        /// 生成（通常指自动生成）
        /// </summary>
        public const string Generate = nameof(Generate);
        /// <summary>
        /// 清除
        /// </summary>
        public const string Clean = nameof(Clean);
        /// <summary>
        /// 更新订阅
        /// </summary>
        public const string UpgradeSubscription = nameof(UpgradeSubscription);
    }
}
