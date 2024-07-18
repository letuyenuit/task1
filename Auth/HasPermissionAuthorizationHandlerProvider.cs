using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace netcore_devsecops.Auth
{
    public class HasPermissionAuthorizationHandlerProvider : DefaultAuthorizationPolicyProvider
    {
        public HasPermissionAuthorizationHandlerProvider(IOptions<AuthorizationOptions> options) : base(options)
        {
        }
        public override Task<AuthorizationPolicy?> GetPolicyAsync(string policyId)
        {
            var policy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme);
            policy.AddRequirements(new PermissionRequirement(policyId));
            return Task.FromResult(policy.Build());
        }
    }
}
