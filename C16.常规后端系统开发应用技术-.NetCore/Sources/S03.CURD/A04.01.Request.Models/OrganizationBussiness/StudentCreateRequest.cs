namespace DataCURD.A04._01.Request.Models.OrganizationBussiness
{
    public class StudentCreateRequest : RequestModel
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
        /// 学生归属的班级 Id
        /// </summary>
        public Guid TeachClassId { get; set; }

        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
