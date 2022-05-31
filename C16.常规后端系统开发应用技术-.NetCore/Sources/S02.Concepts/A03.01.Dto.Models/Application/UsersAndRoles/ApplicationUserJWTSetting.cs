namespace WebApiConcepts.A03._01.Dto.Models.Application.UsersAndRoles
{
    public class ApplicationUserJWTSetting
    {
        public string? Issuer { get; set; }     // 颁发着
        public string? Audience { get; set; }   // 使用人
        public string? SecretKey { get; set; }  // 签发密钥
    }
}
