namespace Lp.OnlineLearning.Domain.Models
{
    /// <summary>
    /// 领域对象模型基类
    /// </summary>
    public abstract class DomainModelBase : IDataBase
    {
        /// <summary>
        /// 对象标识，键
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        public DomainModelBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
