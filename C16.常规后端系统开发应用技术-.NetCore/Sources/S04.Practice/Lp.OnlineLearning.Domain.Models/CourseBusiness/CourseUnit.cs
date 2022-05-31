namespace Lp.OnlineLearning.Domain.Models.CourseBusiness
{
    /// <summary>
    /// 课程教学模块的教学单元
    /// </summary>
    public class CourseUnit : DomainModel
    {
        /// <summary>
        /// 单元分值
        /// </summary>
        public int UnitValue { get; set; }
        /// <summary>
        /// 归属的教学模块
        /// </summary>
        public virtual CourseModule? CourseModule { get; set; }

        public CourseUnit()
        {
            Id = Guid.NewGuid();
        }
    }
}
