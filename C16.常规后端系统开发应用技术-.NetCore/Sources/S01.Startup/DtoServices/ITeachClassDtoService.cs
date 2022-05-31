namespace WebApiStartup.DtoServices
{
    public interface ITeachClassDtoService
    {
        Task<TeachClassDto> GetDtoAsync(Guid id);
        Task<List<TeachClassDto>> GetDtoCollection(Expression<Func<TeachClass, bool>> predicate);
    }
}
