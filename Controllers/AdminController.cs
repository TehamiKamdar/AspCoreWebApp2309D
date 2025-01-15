using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebApp2309D.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
