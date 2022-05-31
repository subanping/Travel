namespace WebApiStartup.RequestServices
{
    public interface ITeachClassRequestService
    {
        Expression<Func<TeachClass, bool>> GetSearchPredicat(TeachClassSearchRequest searchRequest);
        Task<bool> AddAsync(TeachClassRequest request);
        Task<bool> UpdateAsync(TeachClassRequest request);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
