namespace Lp.OnlineLearning.Domain.Models.CourseBusiness
{
    /// <summary>
    /// 课程
    /// </summary>
    public class Course : DomainModel
    {
        /// <summary>
        /// 课程状态
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime BeginDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 归属的课程类型
        /// </summary>
        public virtual CourseCategory? CourseCategory { get; set; }

        public Course()
        {
            Id = Guid.NewGuid();
        }
    }
}
