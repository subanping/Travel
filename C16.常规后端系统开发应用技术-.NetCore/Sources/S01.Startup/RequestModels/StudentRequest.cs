namespace WebApiStartup.RequestModels
{
    /// <summary>
    /// 学生数据请求对象（（由前端向后台 API 传输的数据对象））模型，
    /// 前端页面组件定义相应的数据模型时，应该遵守这个模型定义的规格。
    /// 一般情况下，用于前端向后台提交的新增、编辑的数据对象模型
    /// </summary>
    public class StudentRequest
    {
        /// <summary>
        /// 对象 Id （键值）
        /// </summary>
        public Guid Id { get; set; }   
        /// <summary>
        /// 姓名
        /// </summary>
        public string? Name { get; set; }          
        /// <summary>
        /// 简要说明
        /// </summary>
        public string? Description { get; set; }   
        /// <summary>
        /// 业务编码（这里用于学生的学号）
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
        /// 归属班级 Id
        /// </summary>
        public Guid TeachClassId { get; set; }     
        /// <summary>
        /// 班级名称
        /// </summary>
        public string? TeachClassName { get; set; }
    }
}
