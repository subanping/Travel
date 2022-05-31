namespace DataCURD.A04._01.Request.Models
{
    public interface ISearchRequest : IDataBase
    {
        string? Name { get; set; }
        int PageIndex { get; set; }
        int PageSize { get; set; } 
    }
}
