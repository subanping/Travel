
using System.Security.Claims;

namespace WebApiConcepts.A02._03.Domain.Repositories.ForUsersAndRoles
{
    public class UserRepository : IUserRepository //IDomainRepository<ApplicationUser> //:
    {
        private readonly UserManager<ApplicationUser>? _userManager;    // 用户管理
        private readonly RoleManager<ApplicationRole>? _roleManager;    // 用户管理
        private readonly DomainDataDbContext _dbContext;

        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, DomainDataDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetUserAsync(Guid id) => await _userManager!.FindByIdAsync(id.ToString());

        public async Task<ApplicationUser> GetUserAsync(string userName) => await _userManager!.FindByNameAsync(userName);

        public async Task<List<string>> GetUserRoleNameCollectionAsync(string userName)
        {
            var user = await _userManager!.FindByNameAsync(userName);
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public async Task<DataPager<ApplicationUser>> GetUsersDataPagerAsync(Expression<Func<ApplicationUser, bool>> predicate, int pageIndex, int pageSize) 
        {
            IQueryable<ApplicationUser> dbSet = _userManager!.Users;

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

                return new DataPager<ApplicationUser>(pageIndex, pageSize, totalCount, collection);
            }
            else
            {
                var totalCount = await dbSet!.CountAsync();
                if (pageSize == 0)
                {
                    pageSize = totalCount;
                }
                var collection = dbSet!.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return new DataPager<ApplicationUser>(pageIndex, pageSize, totalCount, collection);
            }
        }

        public async Task<List<Claim>> GetUserClaimCollection(string userName)
        {
            var user = await _userManager!.FindByNameAsync(userName);
            var result = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(LpfwClaims.Fullname, user.UserName),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty)
            };
            result.AddRange(await _userManager!.GetClaimsAsync(user));
            return result;
        }


        public async Task<bool> HasUserAsync(Guid id)
        {
            var user = await _userManager!.FindByIdAsync(id.ToString());
            return user != null;
        }

        public async Task<bool> HasUserAsync(string userName)
        {
            var user = await _userManager!.FindByNameAsync(userName);
            return user != null;
        }

        public async Task<bool> HasPermissionAsync(string userId, string permission) 
        {
            // 提取用户
            var user = await _userManager!.FindByIdAsync(userId);
            if(user==null)
                return false;
            else
            {
                // 提取用户关联的角色组
                var userRoles = await _userManager.GetRolesAsync(user);
                // 创建许可名称清单
                var permissions = new List<string>();
                // 遍历角色组，提取所有的 ClaimType 类型为 LpfwClaims.Permission 的值，作为许可名称
                foreach (var role in await _roleManager!.Roles
                    .Where(r => userRoles.Contains(r.Name))
                    .ToListAsync())
                {
                    permissions.AddRange(await _dbContext.RoleClaims
                        .Where(rc => rc.RoleId == role.Id && rc.ClaimType == LpfwClaims.Permission)
                        .Select(rc => rc.ClaimValue)
                        .ToListAsync());
                }
                // 去重后返回
                var result = permissions.Distinct().ToList().Count();

                return result > 0;

            }


        }

        public async Task<bool> AddUserAsync(ApplicationUser user, string password) 
        {
            var result= await _userManager!.CreateAsync(user);
            if (!string.IsNullOrEmpty(password))
            {
                await _userManager!.AddPasswordAsync(user, password);
            }else
                await _userManager!.AddPasswordAsync(user, "1234@Abcd");

            return result != IdentityResult.Success;
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user) 
        {
            var result = await _userManager!.UpdateAsync(user);
            return result != IdentityResult.Success;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userManager!.FindByIdAsync(id.ToString());
            var result = await _userManager!.UpdateAsync(user);
            return result != IdentityResult.Success;
        }


        public async Task<List<string>> GetPermissionCollectionAsync(string userId, CancellationToken cancellationToken)
        {
            // 提取用户
            var user = await _userManager!.FindByIdAsync(userId);
            if (user == null)
                return new List<string>();
            else
            {
                // 提取用户关联的角色组
                var userRoles = await _userManager.GetRolesAsync(user);
                // 创建许可名称清单
                var permissions = new List<string>();
                // 遍历角色组，提取所有的 ClaimType 类型为 LpfwClaims.Permission 的值，作为许可名称
                foreach (var role in await _roleManager!.Roles
                    .Where(r => userRoles.Contains(r.Name))
                    .ToListAsync())
                {
                    permissions.AddRange(await _dbContext.RoleClaims
                        .Where(rc => rc.RoleId == role.Id && rc.ClaimType == LpfwClaims.Permission)
                        .Select(rc => rc.ClaimValue)
                        .ToListAsync());
                }
                // 去重后返回
                return permissions.Distinct().ToList();
            }

        }
    }
}
