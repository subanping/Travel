namespace DataCURD.A02._01.Domain.Models.Application.UsersAndRoles
{
    public class ApplicationUser : IdentityUser<Guid>, IDataBase
    {
        public bool IsActive { get; set; }                   // 是否是活动的用户
        public string? RefreshToken { get; set; }            // 更新的 Token
        public DateTime RefreshTokenExpiryTime { get; set; } // 更新的Token 过期的时间

        public string? ObjectId { get; set; }                // 与用户关联的对象的 Id
    }
}
