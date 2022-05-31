namespace DataCURD.A02._03.Domain.Repositories.ForUsersAndRoles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserManager<ApplicationUser>? _userManager;    // 用户管理
        private readonly RoleManager<ApplicationRole>? _roleManager;    // 角色管理

        public RoleRepository(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager
            )
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ApplicationRole> GetRoleAsync(Guid id) => await _roleManager!.FindByIdAsync(id.ToString());

        public async Task<ApplicationRole> GetRoleAsync(string roleName) => await _roleManager!.FindByNameAsync(roleName);

        public async Task<List<ApplicationUser>> GetRoleUserCollectionAsync(string roleName)
        {
            return (await _userManager!.GetUsersInRoleAsync(roleName)).ToList();
        }

        public async Task<DataPager<ApplicationRole>> GetRolesDataPagerAsync(Expression<Func<ApplicationRole, bool>> predicate, int pageIndex, int pageSize)
        {
            IQueryable<ApplicationRole> dbSet = _roleManager!.Roles;

            if (predicate != null)
            {
                // 提取总量
                var totalCount = await dbSet!.Where(predicate).CountAsync();
                if (pageSize == 0)
                {
                    // page=0 意味着不分页，亦即每页的条目容量是所有数据的条目总数
                    pageSize = totalCount;
                }
                // 提取分页数据
                var collection = dbSet!
                    .Where(predicate)                   // 查询条件
                    .Skip((pageIndex - 1) * pageSize)   // 跳转到起始取数据的位置
                    .Take(pageSize);                    // 提取起始位置后连续 pageSize 条数据

                return new DataPager<ApplicationRole>(pageIndex, pageSize, totalCount, collection);
            }
            else
            {
                var totalCount = await dbSet!.CountAsync();
                if (pageSize == 0)
                {
                    pageSize = totalCount;
                }
                var collection = dbSet!.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return new DataPager<ApplicationRole>(pageIndex, pageSize, totalCount, collection);
            }

        }

        public async Task<bool> HasRoleAsync(Guid id)
        {
            if (await _roleManager!.FindByIdAsync(id.ToString()) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> HasRoleAsync(string roleName)
        {
            if (await _roleManager!.FindByNameAsync(roleName) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> AddRoleAsync(ApplicationRole role)
        {
            var result = await _roleManager!.CreateAsync(role);
            if (result == IdentityResult.Success)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateRoleAsync(ApplicationRole role)
        {
            var result = await _roleManager!.UpdateAsync(role);
            if (result == IdentityResult.Success)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _roleManager!.FindByIdAsync(id.ToString());
            var result = await _roleManager!.DeleteAsync(role);
            if (result == IdentityResult.Success)
                return true;
            else
                return false;
        }
    }
}
