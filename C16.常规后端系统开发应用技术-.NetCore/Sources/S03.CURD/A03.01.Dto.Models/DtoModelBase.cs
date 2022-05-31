namespace DataCURD.A03._01.Dto.Models
{
    /// <summary>
    /// 仅包含标识符的模型
    /// </summary>
    public abstract class DtoModelBase : IDtoModelBase
    {
        /// <summary>
        /// 对象标识符
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 列表使用的编号
        /// </summary>
        public string? OrderNumber { get; set; }
    }
}
