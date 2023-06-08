using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Models.Context;
using System.Diagnostics;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext context = new DatabaseContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (context.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() 
                    && context.Users.Any(x => x.Password.ToLower() == model.Password.ToLower())))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if(context.Users.Any(x => x.Email.ToLower() == model.Email.ToLower()))
                {
                    return Content("Bu email kayıtlı");
                }
                
                if (context.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    return Content("Bu kullanıcı adı alınmış");
                }

                context.Users.Add(new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = true,
                    IsAdmin = false,
                    CreatedUser = "register",
                    CreatedAt = DateTime.Now,
                });
                context.SaveChanges();

                return RedirectToAction("Login");
            }
            
            return View(model);
        }
        public IActionResult ProfileShow()
        {
            return View();
        }
        public IActionResult ProfileEdit()
        {
            return View();
        }
        public IActionResult DeleteProfile()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}