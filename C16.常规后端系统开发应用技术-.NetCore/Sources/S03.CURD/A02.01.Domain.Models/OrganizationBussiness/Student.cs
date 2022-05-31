using DataCURD.A02._01.Domain.Models.Application.UsersAndRoles;

namespace DataCURD.A02._01.Domain.Models.OrganizationBussiness
{
    /// <summary>
    /// 学生领域对象模型
    /// </summary>
    public class Student : DomainModel
    {
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
        /// <summary>
        /// 头像路径
        /// </summary>
        [StringLength(30)]
        public string? ImageUrl { get; set; }  // 关联人员的头像

        /// <summary>
        /// 归属班级
        /// </summary>
        public virtual TeachClass? TeachClass { get; set; }
        /// <summary>
        /// 关联用户
        /// </summary>
        public virtual ApplicationUser? AppllicationUser { get; set; }
    }
}
