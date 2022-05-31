namespace WebApiConcepts.A02._03.Domain.Repositories.ForUsersAndRoles
{
    /// <summary>
    /// 用户数据管理仓储接口定义
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 根据 Id 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationUser> GetUserAsync(Guid id);
        /// <summary>
        /// 根据用户名，获取用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ApplicationUser> GetUserAsync(string userName);
        /// <summary>
        /// 根据用户名，获取用户关联的全部的角色组名称集合
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<List<string>> GetUserRoleNameCollectionAsync(string userName);
        /// <summary>
        /// 根据查询条件和分页参数，获取按分页方式组成的用户数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<DataPager<ApplicationUser>> GetUsersDataPagerAsync(Expression<Func<ApplicationUser, bool>> predicate, int pageIndex, int pageSize);
        /// <summary>
        /// 根据用户名称，获取用户拥有的全部 Claim，包括：
        ///   1. 用户自己拥有的；
        ///   2. 用户归属的角色组拥有的。
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<List<Claim>> GetUserClaimCollection(string userName);
        /// <summary>
        /// 根据 Id 检查是否存在相应的用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> HasUserAsync(Guid id);
        /// <summary>
        /// 根据用户名检查是否存在相应的用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> HasUserAsync(string userName);
        /// <summary>
        /// 根据用户名和许可名称，检查是否存在相应的权限许可
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        Task<bool> HasPermissionAsync(string userId, string permission);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> AddUserAsync(ApplicationUser user, string password);
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UpdateUserAsync(ApplicationUser user);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUserAsync(Guid id);
        /// <summary>
        /// 提取用户的全部访问许可
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<string>> GetPermissionCollectionAsync(string userId, CancellationToken cancellationToken);
    }
}
