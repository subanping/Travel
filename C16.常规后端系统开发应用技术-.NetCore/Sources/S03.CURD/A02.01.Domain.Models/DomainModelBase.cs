namespace DataCURD.A02._01.Domain.Models
{
    public abstract class DomainModelBase : IDataBase
    {
        [Key]
        public Guid Id { get; set; }

        public DomainModelBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
