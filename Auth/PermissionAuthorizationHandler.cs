using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using netcore_devsecops.Database;
using netcore_devsecops.Models;

namespace netcore_devsecops.Auth
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            try
            {
                using IServiceScope scope = _serviceScopeFactory.CreateScope();
                ApplicationDbContext dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
                string userId = context.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                var roleId = dbContext.Users.FirstOrDefault(x => x.IdUser == new Guid(userId)).IdRole;
                var rolePermission = dbContext.RolePermissions.FirstOrDefault(x => x.IdRole == roleId);
                if (rolePermission != null && rolePermission.IsAccessed)
                {
                    context.Succeed(requirement);
                }
                if (rolePermission != null && rolePermission.Role.Name == Policy.admin.ToString()) 
                {
                    context.Succeed(requirement);
                }
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.CompletedTask;
            }
        }
    }
}
