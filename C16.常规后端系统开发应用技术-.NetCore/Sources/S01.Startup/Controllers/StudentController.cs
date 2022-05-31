
namespace WebApiStartup.Controllers
{
    /// <summary>
    /// 学生数据管理
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")] // 声明控制器的操作支持 application/json 的响应内容类型
    public class StudentController : ControllerBase
    {
        /// <summary>
        /// 数据传输对象服务：负责根据查询条件，从领域对象仓储中获取数据并生成相应的数据传输对象
        /// </summary>
        private readonly IStudentDtoService _studentDtoService;
        /// <summary>
        /// 请求数据对象（值对象）服务：负责根据查询请求对象（值对象），生成相应的查询条件供数据传输对象服务使用，
        /// 以及根据数据处理请求对象（值对象），将请求对象提交到领域对象仓储中进行处理，并返回处理结果状态信息。
        /// </summary>
        private readonly IStudentRequestService _studentRequestService;

        /// <summary>
        /// 构造函数，负责注入数据处理服务
        /// </summary>
        /// <param name="studentDtoService"></param>
        /// <param name="studentRequestService"></param>
        public StudentController(IStudentDtoService studentDtoService, IStudentRequestService studentRequestService)
        {
            _studentDtoService = studentDtoService;
            _studentRequestService = studentRequestService;
        }

        /// <summary>
        /// 根据默认的查询请求对象，获取满足条件的 DTO 对象集合，供前端使用
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<DataPaginated<StudentDto>> Get()
        {
            // 创建默认的查询请求对象
            var studentSearchRequest= new StudentSearchRequest();
            // 获取查询条件
            var predicte = _studentRequestService.GetSearchPredicat(studentSearchRequest);
            // 根据查询条件获取满足条件的数据传输对象的集合
            var result= await _studentDtoService.GetDtoDataPaginated(predicte,studentSearchRequest.PageIndex, studentSearchRequest.PageSize);
            // 返回结果
            return result;
        }

        /// <summary>
        /// 根据查询请求的值对象，获取满足条件的学生数据传输对象集合，供前端使用
        /// </summary>
        /// <param name="studentSearchRequest">查询请求对象（值对象）</param>
        /// <returns>加载在分页模型中的学生数据</returns>
        /// <remarks>
        /// 请求数据的样例：
        ///
        ///     POST /Student/Search
        ///     {
        ///        "id": '',
        ///        "name": "张",
        ///        "province": "广西壮族自治区"
        ///        "teachClassId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///        "pageIndex": 2
        ///        "pageSize": 15
        ///     }
        ///
        /// </remarks>        
        [HttpPost("Search")]
        public async Task<DataPaginated<StudentDto>> Search([FromBody] StudentSearchRequest studentSearchRequest)
        {
            // 获取查询条件
            var predicate = _studentRequestService.GetSearchPredicat(studentSearchRequest);
            // 根据查询条件获取满足条件的数据传输对象的集合
            var result = await _studentDtoService.GetDtoDataPaginated(predicate, studentSearchRequest.PageIndex, studentSearchRequest.PageSize);
            // 返回结果
            return result;
        }

        /// <summary>
        /// 根据查询请求值对象的特征值（这里是对象的 Id），获取单个的学生数据传输对象，供前端使用
        /// </summary>
        /// <param name="id">希望获取的数据对象的 Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<StudentDto> GetStudent(Guid id)
        {
            var result = await _studentDtoService.GetDtoAsync(id);
            return result;
        }

        /// <summary>
        /// 将前端前端提交的服务请求值对象，映射为领域对象，然后添加到领域对象中（持久化）
        /// </summary>
        /// <param name="studentRequest">提交新增的学生数据请求对象</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<bool> Add([FromBody] StudentRequest studentRequest)
        {
            // 映射为领域对象，然后添加到领域对象中
            var result = await _studentRequestService.AddAsync(studentRequest);
            return result;
        }

        /// <summary>
        /// 将前端前端提交的服务请求值对象，映射为领域对象，并修改领域对象的属性数据的值（持久化）
        /// </summary>
        /// <param name="studentRequest">提交更新的学生数据请求对象</param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<bool> Update([FromBody] StudentRequest studentRequest)
        {
            // 映射为领域对象，并修改领域对象的属性数据的值
            var result = await _studentRequestService.UpdateAsync(studentRequest);
            return result;
        }

        /// <summary>
        /// 根据查询请求值对象的特征值（这里是对象的 Id），删除相应的领域对象（持久化）
        /// </summary>
        /// <param name="id">待删除的学生对象的 Id</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<bool> Delete(Guid id)
        {
            // 删除相应的领域对象（持久化
            var result = await _studentRequestService.DeleteByIdAsync(id);
            return result;
        }
    }
}
