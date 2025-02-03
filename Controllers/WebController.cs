using AspCoreWebApp2309D.dbContext;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebApp2309D.Controllers
{
    public class WebController : Controller
    {
        sqlDb db;

        public WebController(sqlDb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString("Name");
            ViewBag.username = name;
            var products = db.tblProducts.ToList();
            return View(products);
        }
        public IActionResult Menu()
        {
            return View();
        }
    }
}
