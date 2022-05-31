namespace WebApiStartup.DtoServices
{
    public class TeachClassDtoService : ITeachClassDtoService
    {
        private readonly ITeachClassRepository? _teachClassRepository;

        public TeachClassDtoService(ITeachClassRepository? teachClassRepository)
        {
            _teachClassRepository = teachClassRepository;
        }

        public async Task<TeachClassDto> GetDtoAsync(Guid id) 
        {
            var teachClass=await _teachClassRepository!.FindByIdAsync(id);
            return _DtoMapper(teachClass);
        }

        public async Task<List<TeachClassDto>> GetDtoCollection(Expression<Func<TeachClass, bool>> predicate) 
        { 
            var result= new List<TeachClassDto>();
            var teachClassCollection= await _teachClassRepository!.GetAllAsync(predicate);
            
            var counter = 0;
            foreach (var teachClass in teachClassCollection)
            {
                var dto=_DtoMapper(teachClass);
                dto.OrderCode = (++counter).ToString();
                result.Add(dto);
            }

            return result;
        }

        private TeachClassDto _DtoMapper(TeachClass teachClass)
        {
            var dto = new TeachClassDto();
            if (teachClass != null)
            {
                dto.Id          = teachClass.Id;
                dto.Name        = teachClass.Name;
                dto.Description = teachClass.Description;
                dto.SortCode    = teachClass.SortCode;
            }
            return dto;
        }


    }
}
