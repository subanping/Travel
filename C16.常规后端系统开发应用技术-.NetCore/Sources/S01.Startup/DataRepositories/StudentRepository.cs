namespace WebApiStartup.DataRepositories
{
    /// <summary>
    /// 针对仓储接口 <see cref="IStudentRepository" /> 的具体实现。
    /// </summary>
    public class StudentRepository: IStudentRepository
    {
        /// <summary>
        /// EF 中实现领域模型对象和关系数据库表对象映射关联上下文对象
        /// </summary>
        private readonly DataContext _dataContext;
        
        public StudentRepository(DataContext dataContext) 
        {
            _dataContext = dataContext; 
        }

        public async Task<int> CountAsync() => await _dataContext.Students!.CountAsync() ;

        public async Task<int> CountAsync(Expression<Func<Student, bool>> predicate) => await _dataContext.Students!.Where(predicate).CountAsync() ;

        public async Task<Student> GetAsync(Guid id) => (await _dataContext!.Students!.Include(x=>x.TeachClass).FirstOrDefaultAsync(x=>x.Id == id))!;

        public async Task<Student> GetAsync(Expression<Func<Student, bool>> predicate) =>
            (await _dataContext!.Students!.Include(x => x.TeachClass).FirstOrDefaultAsync(predicate))!;

        public async Task<List<Student>> GetAllAsync() => await _dataContext.Students!.Include(x=>x.TeachClass).ToListAsync();
        
        public async Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>> predicate) => 
            await _dataContext.Students!.Include(x => x.TeachClass).Where(predicate).ToListAsync();

        /// <summary>
        /// 根据查询条件，获取仓储中满足条件，并且按照给定批次（页码）、批量（每页条数）返回的领域对象集合
        /// </summary>
        /// <param name="predicate">查询条件表达式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条目数量</param>
        /// <returns></returns>
        public async Task<DataPaginated<Student>> GetDataPaginatedList(Expression<Func<Student, bool>> predicate, int pageIndex, int pageSize) 
        {
            if (predicate != null)
            {
                // 提取学生总量
                var totalCount = await _dataContext.Students!.Where(predicate).CountAsync();
                if (pageSize == 0)
                {
                    // page=0 意味着不分页，亦即每页的条目容量是所有数据的条目总数
                    pageSize = totalCount;
                }
                // 提取分页数据
                var collection = _dataContext.Students!.Include(x => x.TeachClass)  // 包含关联班级数据的学生数据 
                    .Where(predicate)                   // 查询条件
                    .Skip((pageIndex - 1) * pageSize)   // 跳转到起始取数据的位置
                    .Take(pageSize);                    // 提取起始位置后连续 pageSize 条数据

                return new DataPaginated<Student>(pageIndex, pageSize, totalCount, collection);
            }
            else
            {
                var totalCount = await _dataContext.Students!.CountAsync();
                if (pageSize == 0)
                {
                    pageSize = totalCount;
                }
                var collection = _dataContext.Students!.Include(x => x.TeachClass).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return new DataPaginated<Student>(pageIndex, pageSize, totalCount, collection);
            }
        }

        public async Task<bool> HasAsync(Guid id) => await _dataContext.Students!.AnyAsync(x => x.Id == id);

        public async Task<bool> AddAsync(Student student)
        {
            if (student == null)  
                return false;
            else
            {
                try
                {
                    _dataContext.Students?.Add(student);
                    await _dataContext.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            if(student == null)
                return false ;
            else
            {
                try
                {
                    _dataContext.Students?.Update(student);
                    await _dataContext.SaveChangesAsync();
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
            var student = await _dataContext!.Students!.FindAsync(id);
            if(student==null)
                return false;
            else
            {
                try
                {
                    _dataContext.Students.Remove(student);
                    await _dataContext.SaveChangesAsync();
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
