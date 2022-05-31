namespace WebApiConcepts.A04._01.Request.Models
{
    public class SearchRequest : ISearchRequest
    {
        public Guid Id { get; set; }    
        public string? Name { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 18;
    }
}
