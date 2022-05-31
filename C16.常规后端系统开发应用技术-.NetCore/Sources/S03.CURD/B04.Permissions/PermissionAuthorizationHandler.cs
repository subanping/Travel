namespace DataCURD.B04.Permissions
{
    /// <summary>
    /// 许可授权处理器
    /// </summary>
    internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        /// <summary>
        /// 用户数据处理服务接口
        /// </summary>
        private readonly IUserRequestModelService _userRequestService;

        public PermissionAuthorizationHandler(IUserRequestModelService userRequestService)
        {
            _userRequestService = userRequestService;
        }

        /// <summary>
        /// 重写的处理方法，用于比较授权需求和用户是否具有授权需求指定的授权许可（存放在用户关联的 Claim 中）
        /// </summary>
        /// <param name="context">授权处理上下文</param>
        /// <param name="requirement">许可需求</param>
        /// <returns></returns>
        protected override async Task HandleRequirementAsync (
            AuthorizationHandlerContext context, 
            PermissionRequirement requirement)
        {
            // 如果从上下文获取的 User 中提取的用户 Id 有效，并且通过这个 Id 检索的授予用户的访问许可存在
            if (context.User?.GetUserId() is { } userId &&
                await _userRequestService.HasPermissionAsync(userId, requirement.Permission))
            {
                // 许可通过
                context.Succeed(requirement);
            }
        }
    }
}
