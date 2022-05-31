namespace DataCURD.A04._01.Request.Models.Application.UsersAndRoles
{
    public class ApplicationUserLoginRequest : RequestModelBase
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
