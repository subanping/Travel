namespace WebApiConcepts.B02.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeachClassRoomController : BaseApiController<TeachClassRoom, TeachClassRoomRequest, SearchRequest, TeachClassRoomDto>
    {
        public TeachClassRoomController(
            IDtoModelService<TeachClassRoom, TeachClassRoomDto> dtoService,
            ISearchRequestService<TeachClassRoom, SearchRequest> searchRequestService,
            IRequestModelService<TeachClassRoom, TeachClassRoomRequest> requestService
            ) : base(dtoService, searchRequestService, requestService)
        {
            this.IsDataPager = false;
            this.DataPagerPageSize = 0;
        }
    }
}
