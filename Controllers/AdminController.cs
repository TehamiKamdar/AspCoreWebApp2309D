using AspCoreWebApp2309D.dbContext;
using AspCoreWebApp2309D.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebApp2309D.Controllers
{
    public class AdminController : Controller
    {
        sqlDb db;

        public AdminController(sqlDb db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View(db.tblProducts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Products prod)
        {
            db.tblProducts.Add(prod);
            db.SaveChanges();
            ViewBag.success = "Product Inserted";
            ModelState.Clear();
            return View();
        }
    }
}
