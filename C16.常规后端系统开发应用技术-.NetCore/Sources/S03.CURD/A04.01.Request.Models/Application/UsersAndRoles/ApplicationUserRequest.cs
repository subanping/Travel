namespace DataCURD.A04._01.Request.Models.Application.UsersAndRoles
{
    public class ApplicationUserRequest: RequestModelBase
    {
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
