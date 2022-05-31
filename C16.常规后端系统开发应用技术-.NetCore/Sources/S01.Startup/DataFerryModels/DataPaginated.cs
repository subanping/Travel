namespace WebApiStartup.DataFerryModels
{
    /// <summary>
    /// 用于处理分页的数据集合的中间模型
    /// </summary>
    /// <typeparam name="T">待分页对象的类型</typeparam>
    public class DataPaginated<T> where T : class, new()
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页的行数，如果指定每页行数为 0，则做不分页的处理
        /// </summary>
        public int PageSize { get; set; } = 15;
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
            get { return (PageIndex > 1); }
            set { }
        }
        /// <summary>
        /// 是否有后一页
        /// </summary>
        public bool HasNextPage
        {
            get { return (PageIndex < TotalPageCount); }
            set { }
        }
        
        /// <summary>
        /// 当前页的数据元素集合
        /// </summary>
        public List<T> DataCollection { get; set; } = new List<T>();

        public DataPaginated() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="source">分页的数据集合</param>
        public DataPaginated(int pageIndex, int pageSize, int totalCount, IQueryable<T> source)
        {
            DataCollection = source.ToList();

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
