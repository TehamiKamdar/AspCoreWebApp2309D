using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebApp2309D.Controllers
{
    public class WebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }
    }
}
