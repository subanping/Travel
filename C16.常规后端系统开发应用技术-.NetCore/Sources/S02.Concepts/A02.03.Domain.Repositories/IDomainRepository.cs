
namespace WebApiConcepts.A02._03.Domain.Repositories
{
    /// <summary>
    /// 数据领域对象的仓储数据访问泛型接口，负责提供存库对象的查找、添加、更新和删除，定义接口方法分类如下：
    ///     1. 查询库存数量相关的方法
    ///     2. 查询特定库存对象的方法
    ///     3. 查询特定库存对象集合的方法
    ///     4. 入库的方法
    ///     5. 更新库存对象的方法
    ///     6. 清除库存对象的方法
    /// </summary>
    /// <typeparam name="TDdo">领域对象模型类型</typeparam>
    public interface IDomainRepository<TDdo> where TDdo : class, IDataBase, new()
    {
        //internal DomainDataDbContext DomainDataDbContext { get; }

        #region 1. 查询库存数量相关的方法
        /// <summary>
        /// 获取当前仓储（数据库）里面的领域泛型对象的总数
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();
        /// <summary>
        /// 根据据查询条件，获取当前仓储（数据库）里面满足查询条件的领域泛型对象总数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TDdo, bool>> predicate);
        /// <summary>
        /// 根据 Id 查找对应的领域泛型对象领域对象是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> HasAsync(Guid id);
        #endregion

        #region 2. 查询特定库存对象的方法
        /// <summary>
        /// 根据 Id 获取单个领域泛型对象的仓储数据
        /// </summary>
        /// <param name="id">待查询领域泛型对象的 Id</param>
        /// <returns></returns>
        Task<TDdo> GetAsync(Guid id);
        //Task<TDdo> GetAsync(Guid id, params Expression<Func<TDdo, object>>[] includeProperties);

        /// <summary>
        /// 根据查询条件，获取单个领域泛型对象的领域对象仓储数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TDdo> GetAsync(Expression<Func<TDdo, bool>> predicate);
        //Task<TDdo> GetAsync(Expression<Func<TDdo, bool>> predicate, params Expression<Func<TDdo, object>>[] includeProperties);
        #endregion

        #region 3. 查询特定库存对象集合的方法
        /// <summary>
        /// 获取仓储中所有的领域泛型对象领域对象集合
        /// </summary>
        /// <returns></returns>
        Task<List<TDdo>> GetAllAsync();
        //Task<List<TDdo>> GetAllAsync();
        /// <summary>
        /// 根据查询条件，获取仓储中满足条件的领域泛型对象领域对象集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TDdo>> GetAllAsync(Expression<Func<TDdo, bool>> predicate);
        /// <summary>
        /// 根据查询条件，获取仓储中满足条件，并且按照给定批次（页码）、批量（每页条数）返回的领域对象集合
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条目数量</param>
        /// <returns></returns>
        Task<DataPager<TDdo>> GetDataPagger(Expression<Func<TDdo, bool>> predicate, int pageIndex, int pageSize);
        #endregion

        #region 4. 入库的方法
        /// <summary>
        /// 入库：将传入的领域泛型对象领域对象添加到仓储中
        /// </summary>
        /// <param name="TDdo"></param>
        /// <returns></returns>
        Task<bool> AddAsync(TDdo ddo);
        #endregion

        #region 5. 更新库存对象的方法
        /// <summary>
        /// 更新（注意不是更换）：使用传入的领域泛型对象领域对象，更新仓储中已经存在的领域泛型对象领域对象的值
        /// </summary>
        /// <param name="TDdo"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TDdo ddo);
        #endregion

        #region 6. 清除库存对象的方法
        /// <summary>
        /// 报废清除出库：根据领域泛型对象领域对象的特征值（这里是 Id），删除仓储中的领域泛型对象对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid id);
        #endregion   
    }
}
