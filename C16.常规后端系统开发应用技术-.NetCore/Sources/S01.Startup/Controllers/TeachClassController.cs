using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiStartup.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeachClassController : ControllerBase
    {
        private readonly ITeachClassDtoService _dtoService;
        private readonly ITeachClassRequestService _requestService;

        public TeachClassController(ITeachClassDtoService dtoService, ITeachClassRequestService requestService)
        {
            _dtoService = dtoService;
            _requestService = requestService;
        }

        [HttpGet("")]
        public async Task<List<TeachClassDto>> Get()
        {
            var searchRequest = new TeachClassSearchRequest();
            var predict = _requestService.GetSearchPredicat(searchRequest);

            var result = await _dtoService.GetDtoCollection(predict);
            return result;
        }

        [HttpPost("Search")]
        public async Task<List<TeachClassDto>> Get([FromBody] TeachClassSearchRequest searchRequest)
        {
            var predict = _requestService.GetSearchPredicat(searchRequest);
            var result = await _dtoService.GetDtoCollection(predict);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<TeachClassDto> GetStudent(Guid id)
        {
            var result = await _dtoService.GetDtoAsync(id);
            return result;
        }

        [HttpPost("Add")]
        public async Task<bool> Add([FromBody] TeachClassRequest request)
        {
            var result = await _requestService.AddAsync(request);
            return result;
        }

        [HttpPost("Update")]
        public async Task<bool> Update([FromBody] TeachClassRequest request)
        {
            var result = await _requestService.UpdateAsync(request);
            return result;
        }

        [HttpDelete("Delete/{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var result = await _requestService.DeleteByIdAsync(id);
            return result;
        }

    }
}
