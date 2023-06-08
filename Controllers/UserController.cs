using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using MyApp.Models.Context;

namespace MyApp.Controllers
{
    public class UserController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        public IActionResult Index()
        {
            var users = context.Users.ToList();

            return View(users);
        }

        public IActionResult Details(int id)
        {
            var users = context.Users.Find(id);

            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (context.Users.Any(x => x.Email.ToLower() == model.Email.ToLower()))
                {
                    return Content("Bu email kayıtlı");
                }

                if (context.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    return Content("Bu kullanıcı adı alınmış");
                }
                context.Users.Add(new User
                {
                    FullName = model.Fullname,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = model.IsActive,
                    IsAdmin = model.IsAdmin,
                    CreatedUser = "register",
                    CreatedAt = DateTime.Now,
                });
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var users = context.Users.Find(id);
            if (users == null)
                return RedirectToAction("Index");
            
            User model = new User
            {
                FullName = users.Email,
                Username = users.Username,
                Email = users.Email,
                Password = users.Password,
                IsActive = users.IsActive,
                IsAdmin = users.IsAdmin,
            };
            context.SaveChanges();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, User model)
        {
            if (ModelState.IsValid)
            {
                context.Update(model);
                context.SaveChanges();
            }   


            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
