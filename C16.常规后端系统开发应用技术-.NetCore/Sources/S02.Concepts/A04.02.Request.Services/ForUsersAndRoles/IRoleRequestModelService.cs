namespace WebApiConcepts.A04._02.Request.Services.ForUsersAndRoles
{
    public interface IRoleRequestModelService
    {
        Expression<Func<ApplicationRole, bool>> GetRoleSearchPredicat(ISearchRequest searchRequest);
        Task<bool> AddRoleAsync(ApplicationRoleRequest request);
        Task<bool> UpdateRoleAsync(ApplicationRoleRequest request);
        Task<bool> DeleteRoleByIdAsync(Guid id);
    }
}
