using WebApiConcepts.A04._01.Request.Models;

namespace WebApiConcepts.A04._02.Request.Services
{
    public interface IRequestModelService<TDdo, TRequest>
        where TDdo : class, IDataBase, new()
        where TRequest : class, IRequestModelBase, new()
    {
        Task<bool> AddAsync(TRequest request);
        Task<bool> UpdateAsync(TRequest request);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
