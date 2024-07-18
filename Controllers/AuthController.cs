using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using netcore_devsecops.Models;
using netcore_devsecops.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using netcore_devsecops.Auth;

namespace netcore_devsecops.Controllers
{

    [Authorize]
    public class AuthController : Controller
    {
        public ApplicationDbContext _dbContext { get; set; }
        public AuthController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Login(LoginVM loginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var account = _dbContext.Users.FirstOrDefault(x => x.Email == loginVM.Email);

                    if (account == null)
                    {
                        TempData["error"] = "Không tìm thấy thông tin tài khoản này trong hệ thống";
                        return View();
                    }
                    if (account.Password != loginVM.Password)
                    {
                        TempData["error"] = "Mật khẩu không chính xác !";
                        return View();
                    }
                    var claims = new List<Claim>
                {
                    new Claim("Id", account.IdUser.ToString()),
                };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMonths(1),
                        IsPersistent = true,

                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                       new ClaimsPrincipal(claimsIdentity),
                       authProperties);
                    return RedirectToAction("Index", "Home");
                }

                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        [HasPermissionAuthorization(Policy.admin)]
        public IActionResult Manager()
        {
            try
            {
                var roles = _dbContext.Roles.Include(x => x.RolePermissions).ThenInclude(x => x.Permission).ToList();
                return View(roles);
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        [HasPermissionAuthorization(Policy.admin)]
        [HttpPost]
        public IActionResult Manager(List<Role> roles)
        {
            try
            {
                _dbContext.Roles.UpdateRange(roles);
                _dbContext.SaveChanges();
                return RedirectToAction("Manager", "Auth");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
