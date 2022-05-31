namespace WebApiStartup.Dtos
{
    /// <summary>
    /// 班级数据传输对象模型，前端页面组件定义相应的数据模型时，
    /// 应该遵守这个模型定义的规格。
    /// </summary>
    public class TeachClassDto
    {
        public Guid Id { get; set; }               // 班级 Id
        public string? Name { get; set; }          // 班级名称
        public string? Description { get; set; }   // 班级说明
        public string? SortCode { get; set; }      // 编码

        public string? OrderCode { get; set; }     // 列表时候用的编号
    }
}
