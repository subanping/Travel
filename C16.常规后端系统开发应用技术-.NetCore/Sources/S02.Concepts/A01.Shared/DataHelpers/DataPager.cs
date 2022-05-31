namespace WebApiConcepts.A01.Shared.DataHelpers
{
    /// <summary>
    /// 数据分页器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataPager<T> where T : class, IDataBase, new()
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页的行数，如果指定每页行数为 0，则做不分页的处理
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 关联数据集合数据总数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 页面总数
        /// </summary>
        public int TotalPageCount { get; set; }
        /// <summary>
        /// 是否有前一页
        /// </summary>
        public bool HasPreviousPage
        {
            set { }
            get { return (PageIndex > 1); }
        }
        /// <summary>
        /// 是否有后一页
        /// </summary>
        public bool HasNextPage
        {
            set { }
            get { return (PageIndex < TotalPageCount); }
        }
        /// <summary>
        /// 分页器中的数据对象集合
        /// </summary>
        public List<T> DataCollection { get; set; } = new List<T>();

        public DataPager() { }

        public DataPager(int pageIndex, int pageSize, int totalCount, IQueryable<T> source)
        {
            DataCollection=source.ToList();
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            if (pageSize == 0)
                TotalPageCount = 1;
            else
                TotalPageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}
