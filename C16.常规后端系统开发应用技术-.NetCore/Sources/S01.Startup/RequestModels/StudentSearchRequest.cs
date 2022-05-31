namespace WebApiStartup.RequestServices
{
    /// <summary>
    /// 学生数据查询数据请求对象模型，用于生成学生领域对象的查询条件。
    /// </summary>
    public class StudentSearchRequest
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string? Name { get; set; } 
        /// <summary>
        /// 省份
        /// </summary>
        public string? Province { get; set; }    
        /// <summary>
        /// 关联的班级 Id
        /// </summary>
        public Guid TeachClassId { get; set; }   
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; } = 1;  
        /// <summary>
        /// 每页条目数量
        /// </summary>
        public int PageSize { get; set; } = 15;  
    }
}
