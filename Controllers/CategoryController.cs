using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Models.Context;

namespace MyApp.Controllers
{
    public class CategoryController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        public IActionResult Index()
        {
            List<Category> categories = context.Categories.ToList();
            return View(categories);
        }
        
        public IActionResult Details()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(new Category
                {
                    Name = model.Name,
                    Description = model.Description
                });
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit()
        {
            return View();
        }
        
        public IActionResult Delete()
        {
            return View();
        }
    }
}
