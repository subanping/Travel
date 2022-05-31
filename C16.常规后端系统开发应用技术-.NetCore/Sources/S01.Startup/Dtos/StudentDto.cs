namespace WebApiStartup.Dtos
{
    /// <summary>
    /// 学生数据传输对象（由后台向前端传输的数据对象）模型，前端页面组件定义
    /// 相应的数据模型时，应该遵守这个模型定义的规格。
    /// </summary>
    public class StudentDto
    {
        /// <summary>
        /// 学生对象标识符（键值）
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 姓名
        /// </summary>
        public string? Name { get; set; }             
        /// <summary>
        /// 简要说明
        /// </summary>
        public string? Description { get; set; }      
        /// <summary>
        /// 业务编码（学生学号）
        /// </summary>
        public string? SortCode { get; set; }         
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDay { get; set; }        
        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }              
        /// <summary>
        /// 省份
        /// </summary>
        public string? Province { get; set; }         
        /// <summary>
        /// 列表时使用的序号
        /// </summary>
        public string? OrderCode { get; set; }        
        /// <summary>
        /// 学生归属的班级 Id
        /// </summary>
        public Guid TeachClassId { get; set; }    
        /// <summary>
        /// 班级名称
        /// </summary>
        public string? TeachClassName { get; set; }
    }
}
