using ClassDatabaseTask.EF;
using ClassDatabaseTask.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ClassDatabaseTask.Controllers
{
    public class ProductController : Controller
    {
        CatalogContext db;
        public ProductController(CatalogContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Products.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();

            TempData["Msg"] = p.Name + " created succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = (from p in db.Products where p.Id == id select p).SingleOrDefault();
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Products.Find(id);
            ViewBag.Categories = db.Categories.ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            db.Products.Update(p);
            db.SaveChanges();

            TempData["Msg"] = p.Name + " updated successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = db.Products.Find(id);
            db.Products.Remove(data);
            db.SaveChanges();

            TempData["Msg"] = id + " deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
