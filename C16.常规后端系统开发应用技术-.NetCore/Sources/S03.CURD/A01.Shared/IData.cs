namespace DataCURD.A01.Shared
{
    public interface IData: IDataBase
    {
        string? Name { get; set; }
        string? Description { get; set; }
        string? SortCode { get; set; }
    }
}
