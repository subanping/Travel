namespace Lp.OnlineLearning.Domain.Models
{
    /// <summary>
    /// 领域对象模型，常规的领域模型都应该继承这个加以实现
    /// </summary>
    public abstract class DomainModel : IData
    {
        /// <summary>
        /// 对象标识
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 数据对象名称
        /// </summary>
        [StringLength(100)]
        public virtual string? Name { get; set; }
        /// <summary>
        /// 数据对象描述
        /// </summary>
        [StringLength(1000)]
        public virtual string? Description { get; set; }
        /// <summary>
        /// 数据对象编码
        /// </summary>
        [StringLength(200)]
        public virtual string? SortCode { get; set; }

        public DomainModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
