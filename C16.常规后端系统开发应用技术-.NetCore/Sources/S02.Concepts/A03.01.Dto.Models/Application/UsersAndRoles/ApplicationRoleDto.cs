namespace WebApiConcepts.A03._01.Dto.Models.Application.UsersAndRoles
{
    public class ApplicationRoleDto: DtoModelBase
    {
        public string? Name { get; set; }

        public virtual ICollection<ApplicationUserDto>? ApplicationUserDtoCollection { get; set; }
    }
}
