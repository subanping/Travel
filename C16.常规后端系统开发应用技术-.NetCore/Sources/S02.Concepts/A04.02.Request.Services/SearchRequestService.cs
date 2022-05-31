using WebApiConcepts.A01.Shared.ExpressionExtensions;

namespace WebApiConcepts.A04._02.Request.Services
{
    public class SearchRequestService<TDdo, TSearchRequest> : ISearchRequestService<TDdo, TSearchRequest>
        where TDdo : class, IDataBase, new()
        where TSearchRequest : class, ISearchRequest, new()
    {
        public Expression<Func<TDdo, bool>> GetSearchPredicat(ISearchRequest searchRequest)
        {
            Expression<Func<TDdo, bool>>? predicate = ExpressionExtension.GetConditionExpression<TDdo>("");
            if(!string.IsNullOrEmpty(searchRequest.Name))
                predicate = ExpressionExtension.GetConditionExpression<TDdo>(searchRequest.Name);

            return predicate!;
        }
    }
}
