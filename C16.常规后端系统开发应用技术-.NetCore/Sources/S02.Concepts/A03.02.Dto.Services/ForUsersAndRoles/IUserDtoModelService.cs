using System.Security.Claims;
using WebApiConcepts.A03._01.Dto.Models.Application.UsersAndRoles;

namespace WebApiConcepts.A03._02.Dto.Services.ForUsersAndRoles
{
    public interface IUserDtoModelService
    {
        Task<ApplicationUserDto> GetUserDtoAsync(Guid id);
        Task<ApplicationUserDto> GetUserDtoAsync(string userName);
        Task<List<string>> GetUserRoleNameAsync(string userName);
        Task<DataPager<ApplicationUserDto>> GetUserDtoDataPager(Expression<Func<ApplicationUser, bool>> predicate, int pageIndex, int pageSize);

        Task<ApplicationUserForDisplayDto> GetUserForDisplayDtoAsync(Guid id);
        Task<List<Claim>> GetUserClaimCollection(string userName);
        Task<List<string>> GetPermissionCollectionAsync(string userId, CancellationToken cancellationToken);
    }
}
