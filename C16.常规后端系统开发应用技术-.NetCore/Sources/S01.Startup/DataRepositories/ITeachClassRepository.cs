using System.Linq.Expressions;
using WebApiStartup.Models;

namespace WebApiStartup.DataRepositories
{
    public interface ITeachClassRepository
    {
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TeachClass, bool>> predicate);

        Task<TeachClass> FindByIdAsync(Guid id);
        Task<TeachClass> FindByConditionAsync(Expression<Func<TeachClass, bool>> predicate);

        Task<List<TeachClass>> GetAllAsync();
        Task<List<TeachClass>> GetAllAsync(Expression<Func<TeachClass, bool>> predicate);




        Task<bool> HasAsync(Guid id);

        Task<bool> AddAsync(TeachClass student);
        Task<bool> UpdateAsync(TeachClass student);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
