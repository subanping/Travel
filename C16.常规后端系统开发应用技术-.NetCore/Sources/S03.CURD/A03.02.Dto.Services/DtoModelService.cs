using DataCURD.A03._02.Dto.Services.Helpers;

namespace DataCURD.A03._02.Dto.Services
{
    public class DtoModelService<TDdo, TDto> : IDtoModelService<TDdo, TDto>
        where TDdo : class, IDataBase, new()
        where TDto : class, IDtoModelBase, new()
    {
        private readonly IDomainRepository<TDdo> _domainRepository;

        public DtoModelService(IDomainRepository<TDdo> domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public async Task<TDto> GetDtoAsync(Guid id)
        {
            var ddo= await _domainRepository.GetAsync(id);
            var dto = DtoMapper.GetDto<TDdo, TDto>(ddo);
            return dto;
        }

        public async Task<TDto> GetDtoAsync(Expression<Func<TDdo, bool>> predicate) 
        {
            var ddo = await _domainRepository.GetAsync(predicate);
            if (ddo != null)
            {
                var dto = DtoMapper.GetDto<TDdo, TDto>(ddo);
                return dto;
            }
            else
                return null!;
        }

        public async Task<DataPager<TDto>> GetDtoDataPager(Expression<Func<TDdo, bool>> predicate, int pageIndex, int pageSize)
        {
            var ddoDataPager = await _domainRepository.GetDataPagger(predicate, pageIndex, pageSize);
            var dtoDataPager = DtoMapper.GetDataPager<TDdo, TDto>(ddoDataPager);
            return dtoDataPager;
        }
    }
}
