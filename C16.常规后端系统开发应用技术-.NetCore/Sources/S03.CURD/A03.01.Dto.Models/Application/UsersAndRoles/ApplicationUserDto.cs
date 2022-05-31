namespace DataCURD.A03._01.Dto.Models.Application.UsersAndRoles
{
    public class ApplicationUserDto : DtoModelBase
    {
        public virtual string? UserName { get; set; }
        public virtual string? PhoneNumber { get; set; }
        public virtual string? Email { get; set; }

        public virtual ICollection<ApplicationRoleDto>? ApplicationRoleDtoCollection { get; set; }
    }
}
