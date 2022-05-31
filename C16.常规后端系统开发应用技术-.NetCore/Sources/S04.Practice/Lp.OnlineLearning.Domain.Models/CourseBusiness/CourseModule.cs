namespace Lp.OnlineLearning.Domain.Models.CourseBusiness
{
    /// <summary>
    /// 课程教学模块
    /// </summary>
    public class CourseModule : DomainModel
    {
        /// <summary>
        /// 模块分值
        /// </summary>
        public int ModuleValue { get; set; }
        /// <summary>
        /// 归属的课程
        /// </summary>
        public virtual Course? Course { get; set; }

        public CourseModule()
        {
            Id = Guid.NewGuid();
        }

    }
}
