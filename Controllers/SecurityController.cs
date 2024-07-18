using Microsoft.AspNetCore.Mvc;

namespace netcore_devsecops.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
