
namespace WebApiConcepts.A03._02.Dto.Services
{
    public interface IDtoModelService<TDdo, TDto>
        where TDdo : class, IDataBase, new()
        where TDto : class, IDtoModelBase, new()
    {
        Task<TDto> GetDtoAsync(Guid id);
        Task<TDto> GetDtoAsync(Expression<Func<TDdo, bool>> predicate);

        Task<DataPager<TDto>> GetDtoDataPager(Expression<Func<TDdo, bool>> predicate, int pageIndex, int pageSize);
    }
}
