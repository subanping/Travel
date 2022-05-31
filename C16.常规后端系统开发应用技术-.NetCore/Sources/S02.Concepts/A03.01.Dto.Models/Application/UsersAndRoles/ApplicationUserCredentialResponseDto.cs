namespace WebApiConcepts.A03._01.Dto.Models.Application.UsersAndRoles
{
    public class ApplicationUserCredentialResponseDto
    {
        public bool? Success { get; set; }                        // 登录状态

        public string? UserName { get; set; }                     // 用户名
        public string? Token { get; set; }                        // 令牌数据
        public DateTime AccessTokenExpirationDate { get; set; }   // 过期时间

        public Guid OrganizationId { get; set; }                  // 用户归属的组织的 Id
        public Guid DepartmentId { get; set; }                    // 用户归属的部门的 Id
        public Guid PerssonId { get; set; }                       // 用户关联的人员的 Id

        public string? OrganizationName { get; set; }
        public string? DepartmentName { get; set; }
        public string? PersonName { get; set; }

        public string? Message { get; set; }                      // 登录后的数据处理情况的说明
        public string? UserTypeClaim { get; set; }                // 用户类型 Claim
        public string? AvatarPath { get; set; }                   // 头像路径

        public ApplicationUserCredentialResponseDto() { }
        public ApplicationUserCredentialResponseDto(ApplicationUser user, string token, DateTime date)
        {
            UserName = user.UserName;
            Token = token;
            AccessTokenExpirationDate = date;
        }
    }
}
