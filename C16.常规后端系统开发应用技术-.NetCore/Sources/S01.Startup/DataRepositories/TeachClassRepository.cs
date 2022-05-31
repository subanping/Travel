namespace WebApiStartup.DataRepositories
{
    public class TeachClassRepository: ITeachClassRepository
    {
        private readonly DataContext _dataContext;

        public TeachClassRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CountAsync()
        {
            return await _dataContext.TeachClasses!.CountAsync();
        }
        public async Task<int> CountAsync(Expression<Func<TeachClass, bool>> predicate)
        {
            return await _dataContext.TeachClasses!.Where(predicate).CountAsync();
        }

        public async Task<List<TeachClass>> GetAllAsync()
        {
            return await _dataContext.TeachClasses!.ToListAsync();
        }

        public async Task<List<TeachClass>> GetAllAsync(Expression<Func<TeachClass, bool>> predicate)
        {
            return await _dataContext.TeachClasses!.Where(predicate).ToListAsync();
        }

        public async Task<TeachClass> FindByIdAsync(Guid id) => (await _dataContext!.TeachClasses!.FindAsync(id))!;

        public async Task<TeachClass> FindByConditionAsync(Expression<Func<TeachClass, bool>> predicate) =>
            (await _dataContext!.TeachClasses!.FirstOrDefaultAsync(predicate))!;

        public async Task<bool> HasAsync(Guid id) => await _dataContext.TeachClasses!.AnyAsync(x => x.Id == id);

        public async Task<bool> AddAsync(TeachClass TeachClass)
        {
            if (TeachClass == null)
                return false;

            _dataContext.TeachClasses!.Add(TeachClass);
            try
            {
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TeachClass TeachClass)
        {
            if (TeachClass == null)
                return false;

            _dataContext.TeachClasses!.Update(TeachClass);
            try
            {
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            if (await HasAsync(id) == false)
                return false;

            var TeachClass = await _dataContext.TeachClasses!.FindAsync(id);
            _dataContext.TeachClasses.Remove(TeachClass!);
            try
            {
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
