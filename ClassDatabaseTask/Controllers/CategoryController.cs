using ClassDatabaseTask.EF;
using ClassDatabaseTask.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ClassDatabaseTask.Controllers
{
    public class CategoryController : Controller
    {
        CatalogContext db;
        public CategoryController(CatalogContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();

            TempData["Msg"] = c.Name + " created successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = (from c in db.Categories where c.Id == id select c).SingleOrDefault();
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Categories.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Category c)
        {
            db.Categories.Update(c);
            db.SaveChanges();

            TempData["Msg"] = c.Id + " updated successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = db.Categories.Find(id);
            db.Categories.Remove(data);
            db.SaveChanges();

            TempData["Msg"] = id + " deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
