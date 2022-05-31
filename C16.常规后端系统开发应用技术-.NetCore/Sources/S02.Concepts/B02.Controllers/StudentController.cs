namespace WebApiConcepts.B02.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [MustHavePermission(LpfwAction.View, LpfwResource.Students)]  // 必须经过许可
    public class StudentController : BaseApiController<Student, StudentEditRequest, StudentSearchRequest, StudentDto>
    {
        private readonly ILogger _logger;
        IDomainRepository<Student> _studentRepository;
        IUserRepository _userRepository;

        IRequestModelService<Student, StudentCreateRequest> _studentCreateRequestService;

        public StudentController(
            ILogger<StudentController> logger,
            IDtoModelService<Student, StudentDto> dtoService,
            IDomainRepository<Student> studentRepository, 
            IUserRepository userRepository,
            ISearchRequestService<Student, StudentSearchRequest> searchRequestService,
            IRequestModelService<Student, StudentCreateRequest> studentCreateRequestService,
            IRequestModelService<Student, StudentEditRequest> requestService
            ) : base(dtoService, searchRequestService, requestService)
        {
            _logger = logger;
            IsDataPager = true;
            DataPagerPageSize = 18;

            _studentCreateRequestService = studentCreateRequestService;
            _studentRepository= studentRepository;
            _userRepository= userRepository;
            _logger.LogInformation("使用了 StudentController 来处理学生数据。");

        }

        [HttpPost("AddAndCreateUser")]
        public async Task<bool> AddAndCreateUser([FromBody] StudentCreateRequest request)
        {
            // 映射为领域对象，然后添加到领域对象中
            var result = await _studentCreateRequestService.AddAndCreateUserAsync(_studentRepository, _userRepository, request);
            return result;
        }

        [HttpDelete("Delete/{id}")]
        [MustHavePermission(LpfwAction.Delete, LpfwResource.Students)]  // 必须经过许可
        public override async Task<bool> Delete(Guid id)
        {
            // 删除相应的领域对象（持久化
            var result = await RequestService!.DeleteByIdAsync(id);
            _logger.LogInformation("删除了 Id 为" +id.ToString()+" 的学生！ ");
            return result;
        }
    }
}
