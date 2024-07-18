using Microsoft.AspNetCore.Authorization;

namespace netcore_devsecops.Auth
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(string permission) {
            _permission = permission;
        }
        public string _permission { get; set; }
    }
}
