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
    }
}
