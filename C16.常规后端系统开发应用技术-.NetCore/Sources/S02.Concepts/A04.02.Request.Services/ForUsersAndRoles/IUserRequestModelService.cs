namespace WebApiConcepts.A04._02.Request.Services.ForUsersAndRoles
{
    public interface IUserRequestModelService
    {
        Expression<Func<ApplicationUser, bool>> GetUserSearchPredicat(ISearchRequest searchRequest);
        Task<bool> AddUserAsync(ApplicationUserRegisterRequest request);
        Task<bool> UpdateUserAsync(ApplicationUserRequest request);
        Task<bool> DeleteUserByIdAsync(Guid id);
        Task<bool> HasPermissionAsync(string userId, string permission);
    }
}
