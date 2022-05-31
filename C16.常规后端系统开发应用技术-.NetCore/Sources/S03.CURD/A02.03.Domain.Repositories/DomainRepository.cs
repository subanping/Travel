
using DataCURD.A02._03.Domain.Repositories.Helpers;
using DataCURD.A02._03.Domain.Repositories.Extenssions;
namespace DataCURD.A02._03.Domain.Repositories
{
    /// <summary>
    /// 针对仓储泛型接口 <see cref="IDomainRepository{TDdo}" /> 的具体实现。
    /// </summary>
    /// <typeparam name="TDdo"></typeparam>
    public class DomainRepository<TDdo> : IDomainRepository<TDdo> where TDdo : class, IDataBase, new ()
    {
        /// <summary>
        /// EF 中实现领域模型对象和关系数据库表对象映射关联上下文对象
        /// </summary>
        private readonly DomainDataDbContext _dbContext;

        internal DomainDataDbContext DomainDataDbContext { get { return _dbContext; } }
        
        public DomainRepository(DomainDataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAsync() => await _dbContext.Set<TDdo>()!.CountAsync();

        public async Task<int> CountAsync(Expression<Func<TDdo, bool>> predicate) => await _dbContext.Set<TDdo>()!.Where(predicate).CountAsync();

        public async Task<TDdo> GetAsync(Guid id)
        {
            IQueryable<TDdo> dbSet = _dbContext!.Set<TDdo>();
            var includePropertyExpressionCollection = DomianModelRelation.GetIncludeExpression<TDdo>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }

            var result = await dbSet!.FirstOrDefaultAsync(x=>x.Id==id);
            return result!;
        }

        public async Task<TDdo> GetAsync(Expression<Func<TDdo, bool>> predicate) 
        {
            IQueryable<TDdo> dbSet = _dbContext!.Set<TDdo>();
            var includePropertyExpressionCollection = DomianModelRelation.GetIncludeExpression<TDdo>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }

            var result = await dbSet!.FirstOrDefaultAsync(predicate);
            return result!;

        }

        public async Task<List<TDdo>> GetAllAsync() 
        {
            IQueryable<TDdo> dbSet = _dbContext!.Set<TDdo>();
            var includePropertyExpressionCollection = DomianModelRelation.GetIncludeExpression<TDdo>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }

            var result = await dbSet!.ToListAsync();
            return result!;
        }

        public async Task<List<TDdo>> GetAllAsync(Expression<Func<TDdo, bool>> predicate)
        {
            IQueryable<TDdo> dbSet = _dbContext!.Set<TDdo>();
            var includePropertyExpressionCollection = DomianModelRelation.GetIncludeExpression<TDdo>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }

            var result = await dbSet!.Where(predicate).ToListAsync();
            return result!;
        }

        /// <summary>
        /// 根据查询条件，获取仓储中满足条件，并且按照给定批次（页码）、批量（每页条数）返回的领域对象集合
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条目数量</param>
        /// <returns></returns>
        public async Task<DataPager<TDdo>> GetDataPagger(Expression<Func<TDdo, bool>> predicate, int pageIndex, int pageSize)
        {
            IQueryable<TDdo> dbSet = _dbContext!.Set<TDdo>();
            var includePropertyExpressionCollection = DomianModelRelation.GetIncludeExpression<TDdo>();
            if (includePropertyExpressionCollection != null)
            {
                foreach (var includePropertyExpression in includePropertyExpressionCollection)
                {
                    dbSet = dbSet.Include(includePropertyExpression);
                }
            }

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

                return new DataPager<TDdo>(pageIndex, pageSize, totalCount, collection);
            }
            else
            {
                var totalCount = await dbSet!.CountAsync();
                if (pageSize == 0)
                {
                    pageSize = totalCount;
                }
                var collection = dbSet!.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return new DataPager<TDdo>(pageIndex, pageSize, totalCount, collection);
            }
        }

        public async Task<bool> HasAsync(Guid id) => await _dbContext.Set<TDdo>()!.AnyAsync(x => x.Id == id);

        public async Task<bool> AddAsync(TDdo ddo)
        {
            if (ddo == null)
                return false;
            else
            {
                try
                {
                    _dbContext.Set<TDdo>()?.Add(ddo);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> UpdateAsync(TDdo ddo)
        {
            if (ddo == null)
                return false;
            else
            {
                try
                {
                    _dbContext.Set<TDdo>()?.Update(ddo);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var ddo = await _dbContext!.Set<TDdo>()!.FindAsync(id);
            if (ddo == null)
                return false;
            else
            {
                try
                {
                    _dbContext.Set<TDdo>().Remove(ddo);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
}
