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

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Users us, string User_Name, string User_Email)
        {
            us.User_Role = "Customer";
            db.tblUsers.Add(us);
            db.SaveChanges();
            ModelState.Clear();

            Customer cs = new Customer
            {
                Customer_Name = User_Name,
                Customer_Email = User_Email,
                User_Id = us.User_Id
            };
            db.customers.Add(cs);
            db.SaveChanges();
            return View();
        }

        public IActionResult Customer()
        {
            return View(db.customers.ToList());
        }
    }
}
