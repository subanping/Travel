namespace WebApiConcepts.A02._03.Domain.Repositories.ForUsersAndRoles
{
    /// <summary>
    /// 系统角色组数据仓储处理方法接口定义
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// 根据 Id 获取角色组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationRole> GetRoleAsync(Guid id);
        /// <summary>
        /// 根据名称获取角色组
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<ApplicationRole> GetRoleAsync(string roleName);
        /// <summary>
        /// 根据名称，获取角色组内的全部用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<List<ApplicationUser>> GetRoleUserCollectionAsync(string roleName);
        /// <summary>
        /// 根据查询条件和分页规格，获取按照分页方式的角色组数据集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<DataPager<ApplicationRole>> GetRolesDataPagerAsync(Expression<Func<ApplicationRole, bool>> predicate, int pageIndex, int pageSize);
        /// <summary>
        /// 根据 Id 检查是否存在相应的角色组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> HasRoleAsync(Guid id);
        /// <summary>
        /// 根据名称检查是否存在相应的角色组
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> HasRoleAsync(string userName);
        /// <summary>
        /// 添加角色组
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> AddRoleAsync(ApplicationRole user);
        /// <summary>
        /// 更新角色组
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UpdateRoleAsync(ApplicationRole user);
        /// <summary>
        /// 删除角色组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteRoleAsync(Guid id);
    }
}
