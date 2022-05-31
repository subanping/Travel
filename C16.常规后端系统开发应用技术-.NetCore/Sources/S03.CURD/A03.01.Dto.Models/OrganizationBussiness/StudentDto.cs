namespace DataCURD.A03._01.Dto.Models.OrganizationBussiness
{
    public class StudentDto : DtoModel
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
        /// <summary>
        /// 学生关联的用户 Id
        /// </summary>
        public Guid ApplicationUserId { get; set; }
        /// <summary>
        /// 学生关联的用户名
        /// </summary>
        public string? ApplicationUserName { get; set; }

    }
}
