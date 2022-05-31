namespace WebApiStartup.RequestModels
{
    public class TeachClassRequest
    {
        public Guid Id { get; set; }               // 班级 Id
        public string? Name { get; set; }          // 班级名称
        public string? Description { get; set; }   // 班级说明
        public string? SortCode { get; set; }      // 编码
    }
}
