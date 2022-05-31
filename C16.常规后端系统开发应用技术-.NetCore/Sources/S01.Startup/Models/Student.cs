using System.ComponentModel.DataAnnotations;

namespace WebApiStartup.Models
{
    /// <summary>
    /// 学生数据领域模型，负责对真实业务环境中业务数据内容和规格进行约束定义，
    /// 同时也是学生数据持久化管理所需要的内容和规格，一般来说，包括基础属性
    /// （规格）与关系属性（规格）两类。
    /// </summary>
    public class Student
    {
        #region 基础属性
        /// <summary>
        /// 学生标识符（键值）
        /// </summary>
        [Key]
        public Guid Id { get; set; } 
        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(10)]
        public string? Name { get; set; }          
        /// <summary>
        /// 简要说明
        /// </summary>
        [StringLength(500)]
        public string? Description { get; set; }   
        /// <summary>
        /// 业务编码（这里是学号）
        /// </summary>
        [StringLength(50)]
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
        [StringLength(10)]
        public string? Province { get; set; }  
        #endregion

        #region 关系属性
        /// <summary>
        /// 归属班级
        /// </summary>
        public virtual TeachClass? TeachClass { get; set; } 
        #endregion

        public Student()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
