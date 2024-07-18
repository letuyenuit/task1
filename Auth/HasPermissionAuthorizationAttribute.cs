using Microsoft.AspNetCore.Authorization;
using netcore_devsecops.Models;

namespace netcore_devsecops.Auth
{
    public class HasPermissionAuthorizationAttribute : AuthorizeAttribute
    {
        public HasPermissionAuthorizationAttribute(Policy policy) : base (policy.ToString()) 
        {
        }
    }
}
