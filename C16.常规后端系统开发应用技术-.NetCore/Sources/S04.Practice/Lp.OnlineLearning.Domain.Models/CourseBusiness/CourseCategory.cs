namespace Lp.OnlineLearning.Domain.Models.CourseBusiness
{
    /// <summary>
    /// 课程类别
    /// </summary>
    public class CourseCategory :DomainModel
    {
        /// <summary>
        /// 上级类别
        /// </summary>
        public virtual CourseCategory? Parent { get; set; }

        public CourseCategory()
        {
            Id = Guid.NewGuid();
        }
    }
}
