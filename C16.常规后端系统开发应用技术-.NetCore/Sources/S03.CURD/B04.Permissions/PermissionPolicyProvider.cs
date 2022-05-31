using Microsoft.Extensions.Options;

namespace DataCURD.B04.Permissions
{
    /// <summary>
    /// 定制的授权策略提供者，用于实现使用设计的授权模型数据进行授权
    /// </summary>
    internal class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        /// <summary>
        /// 缺省的授权策略提供者
        /// </summary>
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        /// <summary>
        /// 获取缺省的授权策略的提供者
        /// </summary>
        /// <returns></returns>
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

        /// <summary>
        /// 根据授权策略名称，提取指定的认证策略
        /// </summary>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(LpfwClaims.Permission, StringComparison.OrdinalIgnoreCase))
            {
                // 创建策略构建器
                var policy = new AuthorizationPolicyBuilder();
                // 添加策略需求定义
                policy.AddRequirements(new PermissionRequirement(policyName));
                // 返回生成的授权策略
                return Task.FromResult<AuthorizationPolicy?>(policy.Build());
            }
            // 返回缺省的授权策略
            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }

        /// <summary>
        /// 获取缺省的授权策略
        /// </summary>
        /// <returns></returns>
        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => Task.FromResult<AuthorizationPolicy?>(null);
    }
}
