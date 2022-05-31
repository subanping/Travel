namespace WebApiStartup.RequestServices
{
    public class TeachClassRequestService : ITeachClassRequestService
    {
        private readonly ITeachClassRepository? _teachClassRepository;

        public TeachClassRequestService(ITeachClassRepository? teachClassRepository)
        {
            _teachClassRepository = teachClassRepository;
        }

        public Expression<Func<TeachClass, bool>> GetSearchPredicat(TeachClassSearchRequest searchRequest)
        {
            Expression<Func<TeachClass, bool>> predicate = x => x.Name!.Contains(string.Empty);
            if (!string.IsNullOrEmpty(searchRequest.Name))
            {
                predicate = x => x.Name!.Contains(searchRequest.Name)
                                || x.SortCode!.Contains(searchRequest.Name);
            }
            return predicate!;
        }

        public async Task<bool> AddAsync(TeachClassRequest request) 
        {
            var teachClass= new TeachClass();
            _MapperRequest(teachClass, request);
            return await _teachClassRepository!.AddAsync(teachClass);
        }

        public async Task<bool> UpdateAsync(TeachClassRequest request)
        {
            var teachClass= await _teachClassRepository!.FindByIdAsync(request.Id);
            if(teachClass==null)
                return false;
            else
            {
                _MapperRequest(teachClass, request);
                return await _teachClassRepository.UpdateAsync(teachClass);
            }
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _teachClassRepository!.DeleteByIdAsync(id);
        }

        private void _MapperRequest(TeachClass teachClass, TeachClassRequest teachClassRequest)
        {
            teachClass.Name = teachClassRequest.Name;
            teachClass.Description = teachClassRequest.Description;
            teachClass.SortCode = teachClassRequest.SortCode;
        }

    }
}
