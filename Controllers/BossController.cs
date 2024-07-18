using Microsoft.AspNetCore.Mvc;

namespace netcore_devsecops.Controllers
{
    public class BossController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
