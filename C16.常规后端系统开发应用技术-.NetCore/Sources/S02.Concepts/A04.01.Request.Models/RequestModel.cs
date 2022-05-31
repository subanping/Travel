namespace WebApiConcepts.A04._01.Request.Models
{
    public abstract class RequestModel : IRequestModel
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
    }
}
