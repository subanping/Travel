namespace Lp.OnlineLearning.Domain.Models.CourseBusiness
{
    /// <summary>
    /// 教学单元的条目内容（知识点）
    ///   Name 单元名称
    ///   Description 单元简要说明
    ///   SortCode 单元编码
    /// </summary>
    public class CourseUnitContentItem : DomainModel
    {
        /// <summary>
        /// 条目分值
        /// </summary>
        public int ItemValue { get; set; }
        /// <summary>
        /// 单元条目的内容，支持 html 代码存储
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 归属的教学单元
        /// </summary>
        public virtual CourseUnit? CourseUnit { get; set; }

        public CourseUnitContentItem()
        {
            Id= Guid.NewGuid();
        }
    }
}
