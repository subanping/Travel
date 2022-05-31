namespace WebApiStartup.DataRepositories
{
    /// <summary>
    /// 学生数据领域对象的仓储数据访问接口，负责提供存库对象的查找、添加、更新和删除，定义接口方法分类如下：
    ///     1. 查询库存数量相关的方法
    ///     2. 查询特定库存对象的方法
    ///     3. 查询特定库存对象集合的方法
    ///     4. 入库的方法
    ///     5. 更新库存对象的方法
    ///     6. 清除库存对象的方法
    /// </summary>
    public interface IStudentRepository
    {
        #region 1. 查询库存数量相关的方法
        /// <summary>
        /// 获取当前仓储（数据库）里面的学生的总数
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();
        /// <summary>
        /// 根据据查询条件，获取当前仓储（数据库）里面满足查询条件的学生总数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<Student, bool>> predicate);
        /// <summary>
        /// 根据 Id 查找对应的学生领域对象是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> HasAsync(Guid id);
        #endregion

        #region 2. 查询特定库存对象的方法
        /// <summary>
        /// 根据 Id 获取单个学生学生领域对象的仓储数据
        /// </summary>
        /// <param name="id">待查询学生的 Id</param>
        /// <returns></returns>
        Task<Student> GetAsync(Guid id);
        /// <summary>
        /// 根据查询条件，获取单个学生的领域对象仓储数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<Student> GetAsync(Expression<Func<Student, bool>> predicate);
        #endregion

        #region 3. 查询特定库存对象集合的方法
        /// <summary>
        /// 获取仓储中所有的学生领域对象集合
        /// </summary>
        /// <returns></returns>
        Task<List<Student>> GetAllAsync();
        /// <summary>
        /// 根据查询条件，获取仓储中满足条件的学生领域对象集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>> predicate);
        /// <summary>
        /// 根据查询条件，获取仓储中满足条件，并且按照给定批次（页码）、批量（每页条数）返回的领域对象集合
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条目数量</param>
        /// <returns></returns>
        Task<DataPaginated<Student>> GetDataPaginatedList(Expression<Func<Student, bool>> predicate, int pageIndex, int pageSize);
        #endregion

        #region 4. 入库的方法
        /// <summary>
        /// 入库：将传入的学生领域对象添加到仓储中
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<bool> AddAsync(Student student);
        #endregion

        #region 5. 更新库存对象的方法
        /// <summary>
        /// 更新（注意不是更换）：使用传入的学生领域对象，更新仓储中已经存在的学生领域对象的值
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Student student);
        #endregion

        #region 6. 清除库存对象的方法
        /// <summary>
        /// 报废清除出库：根据学生领域对象的特征值（这里是 Id），删除仓储中的学生对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Guid id); 
        #endregion
    }
}
