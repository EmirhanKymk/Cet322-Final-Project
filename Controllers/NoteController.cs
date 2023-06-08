using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Models;
using MyApp.Models.Context;

namespace MyApp.Controllers
{
    public class NoteController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LikedList()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Create()
        {
            List<Category> categories = context.Categories.ToList();
            
            List<SelectListItem> selectListItems =
            categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();

            ViewData["categories"] = selectListItems;
            return View();
        }

        [HttpPost]
        public IActionResult Create(NoteModel model)
        {
            Note note = new Note
            {
                Title = model.Title,
                Summary = model.Summary,
                Detail = model.Detail,
                IsDraft = model.IsDraft,
                CategoryId = model.CategoryId,
                CreatedAt = DateTime.Now,
                CreatedUser = "register"
            };
            context.Notes.Add(note);
            context.SaveChanges();
            
            List<Category> categories = context.Categories.ToList();

            List<SelectListItem> selectListItems =
            categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();

            ViewData["categories"] = selectListItems;
            return View();
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
