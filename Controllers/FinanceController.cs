using Microsoft.AspNetCore.Mvc;

namespace netcore_devsecops.Controllers
{
    public class FinanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
