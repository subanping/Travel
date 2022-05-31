namespace WebApiConcepts.A04._01.Request.Models
{
    public abstract class RequestModelBase : IRequestModelBase
    {
        /// <summary>
        /// 对象标识符
        /// </summary>
        public Guid Id { get; set; }
    }
}
