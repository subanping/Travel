using DataCURD.A03._01.Dto.Models.Application.UsersAndRoles;

namespace DataCURD.A03._02.Dto.Services.ForUsersAndRoles
{
    public interface IRoleDtoModelService
    {
        Task<ApplicationRoleDto> GetRoleDtoAsync(Guid id);
        Task<ApplicationRoleDto> GetRoleDtoAsync(string roleName);
        Task<List<ApplicationUserDto>> GetRoleUserDtoCollectionAsync(string roleName);
        Task<DataPager<ApplicationRoleDto>> GetRoleDtoDataPager(Expression<Func<ApplicationRole, bool>> predicate, int pageIndex, int pageSize);
    }
}
