using WebApiConcepts.A02._03.Domain.Repositories.ForUsersAndRoles;
using WebApiConcepts.A03._02.Dto.Services.Helpers;

namespace WebApiConcepts.A03._02.Dto.Services.ForUsersAndRoles
{
    public class RoleDtoModelService : IRoleDtoModelService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleDtoModelService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ApplicationRoleDto> GetRoleDtoAsync(Guid id) 
        {
            var ddo = await _roleRepository.GetRoleAsync(id);
            var dto = DtoMapper.GetDto<ApplicationRole, ApplicationRoleDto>(ddo);
            return dto;
        }

        public async Task<ApplicationRoleDto> GetRoleDtoAsync(string roleName)
        {
            var ddo = await _roleRepository.GetRoleAsync(roleName);
            var dto = DtoMapper.GetDto<ApplicationRole, ApplicationRoleDto>(ddo);
            return dto;
        }

        public async Task<List<ApplicationUserDto>> GetRoleUserDtoCollectionAsync(string roleName)
        {
            var userCollection=await _roleRepository.GetRoleUserCollectionAsync(roleName);
            var userDtoCollection = new List<ApplicationUserDto>();
            foreach (var user in userCollection)
            {
                userDtoCollection.Add(DtoMapper.GetDto<ApplicationUser, ApplicationUserDto>(user));
            }
            return userDtoCollection;
        }

        public async Task<DataPager<ApplicationRoleDto>> GetRoleDtoDataPager(Expression<Func<ApplicationRole, bool>> predicate, int pageIndex, int pageSize)
        {
            var ddoDataPager = await _roleRepository.GetRolesDataPagerAsync(predicate, pageIndex, pageSize);
            var dtoDataPager = DtoMapper.GetDataPager<ApplicationRole, ApplicationRoleDto>(ddoDataPager);
            return dtoDataPager;
        }
    }
}
