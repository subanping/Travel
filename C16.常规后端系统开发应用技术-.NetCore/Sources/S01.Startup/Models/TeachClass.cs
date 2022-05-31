using System.ComponentModel.DataAnnotations;

namespace WebApiStartup.Models
{
    /// <summary>
    /// 教学班级数据领域模型
    /// </summary>
    public class TeachClass
    {
        [Key]
        public Guid Id { get; set; }               // 班级 Id
        public string? Name { get; set; }          // 班级名称
        public string? Description { get; set; }   // 班级说明
        public string? SortCode { get; set; }      // 编码

        public TeachClass()
        {
            Id = Guid.NewGuid();
        }
    }
}
