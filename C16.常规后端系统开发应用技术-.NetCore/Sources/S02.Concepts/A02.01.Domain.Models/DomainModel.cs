namespace WebApiConcepts.A02._01.Domain.Models
{
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
        public string? Name { get; set; }
        /// <summary>
        /// 数据对象描述
        /// </summary>
        [StringLength(1000)]
        public string? Description { get; set; }
        /// <summary>
        /// 数据对象编码
        /// </summary>
        [StringLength(200)]
        public string? SortCode { get; set; }

        public DomainModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
