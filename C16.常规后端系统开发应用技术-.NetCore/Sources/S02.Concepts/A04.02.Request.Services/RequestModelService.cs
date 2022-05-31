using WebApiConcepts.A04._02.Request.Services.Helpers;

namespace WebApiConcepts.A04._02.Request.Services
{
    public class RequestModelService<TDdo, TRequest>: IRequestModelService<TDdo, TRequest>
        where TDdo : class, IDataBase, new()
        where TRequest : class, IRequestModelBase, new()
    {
        private readonly IDomainRepository<TDdo> _domainRepository;   

        public RequestModelService(IDomainRepository<TDdo> domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public virtual async Task<bool> AddAsync(TRequest request)
        {
            var ddo= new TDdo();
            await RequestMapper.SetDomainObject(ddo, request, _domainRepository);
            return await _domainRepository.AddAsync(ddo);
        }
        
        public async Task<bool> UpdateAsync(TRequest request)
        {
            var ddo= await _domainRepository.GetAsync(request.Id);
            await RequestMapper.SetDomainObject(ddo, request, _domainRepository);
            return await _domainRepository.UpdateAsync(ddo);
        }
        
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _domainRepository.DeleteAsync(id);
        }

    }
}
