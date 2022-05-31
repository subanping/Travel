using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiConcepts.B02.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeachClassController : BaseApiController<TeachClass, TeachClassEditRequest, SearchRequest, TeachClassDto>
    {
        public TeachClassController(
            IDtoModelService<TeachClass, TeachClassDto> dtoService,
            ISearchRequestService<TeachClass, SearchRequest> searchRequestService,
            IRequestModelService<TeachClass, TeachClassEditRequest> requestService
            ) : base(dtoService, searchRequestService, requestService)
        {
            this.IsDataPager = false;
            this.DataPagerPageSize = 0;
        }

        /// <summary>
        /// 根据班级名称，返回一个班级到前端
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> Get(string name)
        {
            var dto= await DtoService!.GetDtoAsync(x=>x.Name!.Contains(name));
            return Ok(dto);
        }

        /// <summary>
        /// 使用 httpput 更新班级数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<bool> Update(Guid id, TeachClassEditRequest request)
        {
            // 映射为领域对象，并修改领域对象的属性数据的值
            var result = await RequestService!.UpdateAsync(request);
            return result;
        }
    }
}
