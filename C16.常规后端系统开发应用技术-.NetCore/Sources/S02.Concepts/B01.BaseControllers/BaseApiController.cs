

using WebApiConcepts.B04.Permissions;

namespace WebApiConcepts.B01.BaseControllers
{
    /// <summary>
    /// 基础控制器，负责实现简单的常规数据 CURD 处理
    /// </summary>
    /// <typeparam name="TDdo"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TSearchRequest"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    public abstract class BaseApiController<TDdo, TRequest, TSearchRequest, TDto> : ControllerBase
        where TDdo : class, IDataBase, new()
        where TRequest : class, IRequestModelBase, new()
        where TSearchRequest : class, ISearchRequest, new()
        where TDto : class, IDtoModelBase, new()
    {
        private readonly IDtoModelService<TDdo, TDto>? _dtoService;                             // Dto数据服务
        private readonly ISearchRequestService<TDdo, TSearchRequest>? _searchRequestService;    // 检索模型请求数据服务
        private readonly IRequestModelService<TDdo, TRequest>? _requestService;                 // 请求数据服务

        public IDtoModelService<TDdo, TDto>? DtoService { get { return _dtoService; } }                   // Dto数据服务
        public IRequestModelService<TDdo, TRequest>? RequestService { get { return _requestService; } }   // 请求数据服务
        public ISearchRequestService<TDdo, TSearchRequest>? SearchRequestService { get { return _searchRequestService; } }    // 请求数据服务

        public bool IsDataPager { get; set; } = true;       // 是否分页
        public int DataPagerPageSize { get; set; } = 18;    // 默认每页条目数量

        public BaseApiController(
            IDtoModelService<TDdo, TDto> dtoService,
            ISearchRequestService<TDdo, TSearchRequest> searchRequestService,
            IRequestModelService<TDdo, TRequest> requestService
            )
        {
            _dtoService = dtoService;
            _searchRequestService = searchRequestService;
            _requestService = requestService;
        }

        [HttpGet("All")]
        public virtual async Task<DataPager<TDto>> Get()
        {
            var searchRequest = new SearchRequest() { PageSize = 0};
            if (IsDataPager)
                searchRequest.PageSize = 0;
            else
                searchRequest.PageSize = DataPagerPageSize;

            var predicate = _searchRequestService!.GetSearchPredicat(searchRequest);
            return await _dtoService!.GetDtoDataPager(predicate,searchRequest.PageIndex, searchRequest.PageSize);
        }

        [HttpPost("Search")]
        public virtual async Task<DataPager<TDto>> Search([FromBody] TSearchRequest searchRequest)
        {
            if (IsDataPager)
                searchRequest.PageSize = 0;
            else
                searchRequest.PageSize = DataPagerPageSize;

            // 获取查询条件
            var predicate = _searchRequestService!.GetSearchPredicat(searchRequest);
            // 根据查询条件获取满足条件的数据传输对象的集合
            return await _dtoService!.GetDtoDataPager(predicate, searchRequest.PageIndex, searchRequest.PageSize);
        }

        [HttpGet("{id}")]
        public virtual async Task<TDto> Get(Guid id)
        {
            var result = await _dtoService!.GetDtoAsync(id);
            return result;
        }

        [HttpPost("Add")]
        public virtual async Task<bool> Add([FromBody] TRequest request)
        {
            // 映射为领域对象，然后添加到领域对象中
            var result = await _requestService!.AddAsync(request);
            return result;
        }

        [HttpPost("Update")]
        public virtual async Task<bool> Update([FromBody] TRequest request)
        {
            // 映射为领域对象，并修改领域对象的属性数据的值
            var result = await _requestService!.UpdateAsync(request);
            return result;
        }

        [HttpDelete("Delete/{id}")]
         public virtual async Task<bool> Delete(Guid id)
        {
            // 删除相应的领域对象（持久化
            var result = await _requestService!.DeleteByIdAsync(id);
            return result;
        }
    }
}
