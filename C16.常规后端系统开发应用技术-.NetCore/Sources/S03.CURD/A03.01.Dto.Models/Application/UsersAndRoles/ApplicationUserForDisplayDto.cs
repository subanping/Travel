namespace DataCURD.A03._01.Dto.Models.Application.UsersAndRoles
{
    public class ApplicationUserForDisplayDto : DtoModelBase
    {
        public string? UserName { get; set; }
        public string? DepartmentName { get; set; }
        public string? PersonName { get; set; }
        public string? PersonAvatarUrl { get; set; }
    }
}
