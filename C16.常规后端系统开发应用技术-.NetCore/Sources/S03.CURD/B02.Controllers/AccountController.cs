namespace DataCURD.B02.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser>? _userManager;                 // 用户管理
        private readonly SignInManager<ApplicationUser> _signInManager;              // 登入管理
        private readonly ApplicationUserJWTSetting _jwtSetting;                      // JWT 设置 

        private readonly IUserDtoModelService _userDtoService;                       // 用户 Dto 服务
        private readonly IUserRequestModelService _userRequestService;               // 用户 Request 服务
        private readonly IDtoModelService<Student, StudentDto> _studentDtoService;   // 学生 Dto 服务

        public AccountController(
            UserManager<ApplicationUser> userManager,
            IUserDtoModelService userDtoService,
            IUserRequestModelService userRequestService,
            IOptions<ApplicationUserJWTSetting> jwtSettingOption,
            IDtoModelService<Student, StudentDto> studentDtoService,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _userRequestService = userRequestService;
            _studentDtoService = studentDtoService;

            _signInManager = signInManager;
            _userDtoService = userDtoService;
            _jwtSetting = jwtSettingOption.Value;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<RequestProcessResult> Register([FromBody] ApplicationUserRegisterRequest registerRequest)
        {
            var result = new RequestProcessResult() { Success = false, Message = "数据存在错误，无法增加用户数据！", Result = null };
            var student = await _studentDtoService.GetDtoAsync(x => x.SortCode == registerRequest.UserName);
            if (student == null)
            {
                result.Message = "你提交的用户名不是系统中学生的学号用户名，无法为你注册用户资料！";
                return result;
            }
            else
            {
                result= await _userRequestService.AddUserAsync(registerRequest);
                return result;
            }

        }

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] ApplicationUserLoginRequest loginRequest) 
        {
            var resoponseDto = new ApplicationUserCredentialResponseDto() { Success = false, Message = "用户名或者密码错误！" };
            // 根据用户名提取用户
            var user = await _userManager!.FindByNameAsync(loginRequest.UserName);
            if (user != null)
            {
                // 验证身份：使用密码方式登录系统
                var result = await _signInManager.PasswordSignInAsync(user, loginRequest.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // 获取关联的用户 Claim 集合
                    var claims = await _userDtoService.GetUserClaimCollection(user.UserName);
                    // 创建 token 密钥（使用对称加密算法获取的）
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecretKey!));
                    // 创建系统签名证书
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    // 创建系统登录令牌（登录凭证、登录证件、系统身份证...）
                    var token = new JwtSecurityToken(
                        _jwtSetting.Issuer,
                        _jwtSetting.Audience,
                        claims,
                        DateTime.Now,
                        DateTime.Now.AddDays(30),
                        creds
                        );
                    // 创建供前端使用的登录成功后的响应数据
                    resoponseDto = new ApplicationUserCredentialResponseDto(user, new JwtSecurityTokenHandler().WriteToken(token), DateTime.Now.AddDays(30));
                    resoponseDto.Success = true;
                    return Ok(resoponseDto);
                }
                else
                {
                    resoponseDto.Message = "登录失败：为当前用户提供的用户密码错误！";
                    return BadRequest(resoponseDto);
                }
            }
            else
                return BadRequest(resoponseDto);
        }

        /// <summary>
        /// 获取用户的
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("PermissionCollection")]
        public async Task<ActionResult<List<string>>> GetPermissionCollection(CancellationToken cancellationToken)
        {
            if (User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            return Ok(await _userDtoService.GetPermissionCollectionAsync(userId, cancellationToken));
        }
    }
}
