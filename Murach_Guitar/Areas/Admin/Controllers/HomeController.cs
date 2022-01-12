using Microsoft.AspNetCore.Mvc;

namespace Murach_Guitar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}