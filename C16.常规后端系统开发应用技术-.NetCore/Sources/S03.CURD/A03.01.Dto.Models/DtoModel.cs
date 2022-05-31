namespace DataCURD.A03._01.Dto.Models
{
    /// <summary>
    /// 普通数据传对象模型
    /// </summary>
    public abstract class DtoModel : IDtoModel
    {
        /// <summary>
        /// 对象标识符
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 简要说明
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 业务编码
        /// </summary>
        public string? SortCode { get; set; }
        /// <summary>
        /// 列表使用的编号
        /// </summary>
        public string? OrderNumber { get; set; }
    }
}
