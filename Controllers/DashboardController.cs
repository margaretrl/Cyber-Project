using Microsoft.AspNetCore.Mvc;

namespace CyberProj.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
