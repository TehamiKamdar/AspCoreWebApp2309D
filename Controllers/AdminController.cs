using AspCoreWebApp2309D.dbContext;
using AspCoreWebApp2309D.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace AspCoreWebApp2309D.Controllers
{
    public class AdminController : Controller
    {
        sqlDb db;
        IWebHostEnvironment env;

        public AdminController(sqlDb db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }


        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("Name");
            var role = HttpContext.Session.GetString("Role");
            if (user is not null)
            {
                if (role == "Admin")
                {
                    ViewBag.username = user;
                    return View();
                }
                else
                {
                    ViewBag.username = user;
                    return RedirectToAction("Index", "Web");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Products()
        {
            var user = HttpContext.Session.GetString("Name");
            if (user is not null)
            {
                ViewBag.username = user;
                return View(db.tblProducts.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Create()
        {
            var categories = db.tblCategories.ToList();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Products prod, IFormFile Product_Image)
        {
            string fileName = "";
            var fileExtension = Path.GetExtension(Product_Image.FileName).ToLower();
            if (fileExtension != ".png")
            {
                ViewBag.error = "File Method Not Supported";
                return View();
            }
            else
            {
                string location = Path.Combine(env.WebRootPath, "productImages");
                fileName = Guid.NewGuid().ToString() + "_" + Product_Image.FileName;
                string filePath = Path.Combine(location, fileName);
                Product_Image.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            
            prod.Product_Image = fileName;
            prod.Product_Category = 1;
            db.tblProducts.Add(prod);
            db.SaveChanges();
            ViewBag.success = "Product Inserted";
            ModelState.Clear();
            return RedirectToAction("Create");
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

        public IActionResult Customers()
        {
            return View(db.customers.ToList());
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users us, string User_Email, string User_Password)
        {
            var user = db.tblUsers.FirstOrDefault(x => x.User_Email == User_Email);

            if (user.User_Email == User_Email && user.User_Password == User_Password)
            {
                HttpContext.Session.SetString("Name", user.User_Name);
                HttpContext.Session.SetString("Role", user.User_Role);
                if (user.User_Role == "Admin")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Web");
                }
            }
            else
            {
                ViewBag.error = "User Email and Password is not correct";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Edit(int id)
        {
            var product = db.tblProducts.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Products prod)
        {
            db.tblProducts.Update(prod);
            db.SaveChanges();
            TempData["success"] = "Product Updated";
            return RedirectToAction("Products");
        }
        public IActionResult Delete(int id)
        {
            var product = db.tblProducts.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Products prod)
        {
            db.tblProducts.Remove(prod);
            db.SaveChanges();
            TempData["success"] = "Product Deleted";
            return RedirectToAction("Products");
        }

        public IActionResult Category()
        {
            var categories = db.tblCategories.ToList();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            db.tblCategories.Add(category);
            db.SaveChanges();
            ViewBag.success = "Category Added";
            ModelState.Clear();
            return View();
        }
    }
}
