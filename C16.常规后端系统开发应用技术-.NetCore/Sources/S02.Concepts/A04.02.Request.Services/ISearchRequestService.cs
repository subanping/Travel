namespace WebApiConcepts.A04._02.Request.Services
{
    public interface ISearchRequestService<TDdo, TSearchRequest>
        where TDdo : class, IDataBase, new()
        where TSearchRequest : class, ISearchRequest, new()
    {
        Expression<Func<TDdo, bool>> GetSearchPredicat(ISearchRequest searchRequest);
    }
}
