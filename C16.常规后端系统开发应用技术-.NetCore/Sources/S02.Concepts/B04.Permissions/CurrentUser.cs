namespace WebApiConcepts.B04.Permissions
{
    /// <summary>
    /// 系统当前的用户
    /// 针对接口 <see cref="ICurrentUser}" /> 和 <see cref="ICurrentUserInitializer}" /> 的具体实现。
    /// </summary>
    public class CurrentUser : ICurrentUser, ICurrentUserInitializer
    {
        /// <summary>
        /// 系统当前访问中的用户（持证人）
        /// </summary>
        private ClaimsPrincipal? _user;
        /// <summary>
        /// 用户名
        /// </summary>
        public string? Name => _user?.Identity?.Name;
        /// <summary>
        /// 用户 Id
        /// </summary>
        private Guid _userId = Guid.Empty;

        public Guid GetUserId() =>
            IsAuthenticated()
                ? Guid.Parse(_user?.GetUserId() ?? Guid.Empty.ToString())
                : _userId;

        public string? GetUserEmail() =>
            IsAuthenticated()
                ? _user!.GetEmail()
                : string.Empty;

        public bool IsAuthenticated() =>
            _user?.Identity?.IsAuthenticated is true;

        public bool IsInRole(string role) =>
            _user?.IsInRole(role) is true;

        public IEnumerable<Claim>? GetUserClaims() =>
            _user?.Claims;

        public string? GetTenant() =>
            IsAuthenticated() ? _user?.GetTenant() : string.Empty;

        public void SetCurrentUser(ClaimsPrincipal user)
        {
            if (_user != null)
            {
                throw new Exception("已经做好了处理！");
            }

            _user = user;
        }

        public void SetCurrentUserId(string userId)
        {
            if (_userId != Guid.Empty)
            {
                throw new Exception("已经做好了处理！");
            }

            if (!string.IsNullOrEmpty(userId))
            {
                _userId = Guid.Parse(userId);
            }
        }
    }
}
