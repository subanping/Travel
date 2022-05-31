namespace DataCURD.A04._02.Request.Services.ForUsersAndRoles
{
    public interface IUserRequestModelService
    {
        Expression<Func<ApplicationUser, bool>> GetUserSearchPredicat(ISearchRequest searchRequest);
        Task<RequestProcessResult> AddUserAsync(ApplicationUserRegisterRequest request);

        Task<RequestProcessResult> UpdateUserAsync(ApplicationUserRequest request);
        Task<RequestProcessResult> DeleteUserByIdAsync(Guid id);
        Task<bool> HasPermissionAsync(string userId, string permission);
    }
}
