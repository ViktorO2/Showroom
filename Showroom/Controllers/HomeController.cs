using Microsoft.AspNetCore.Mvc;
using Showroom.ActionFilters;
using Showroom.Entities;
using Showroom.ExtentionMethods;
using Showroom.Repositories;
using Showroom.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Showroom.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!this.ModelState.IsValid)
                return View(model);

            UsersRepository repo=new UsersRepository();
            User loggedUser = repo.FirstOrDefault(u => u.Username == model.Username &&
                                                       u.Password == model.Password);
                                                        
            if (loggedUser == null)
            {
                this.ModelState.AddModelError("authError", "Invalid username or password!");
                return View(model);
            }

            HttpContext.Session.Set("loggedUser", loggedUser);

            return RedirectToAction("Index", "Home");
        }

        [AuthenticationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Login", "Home");
        }


    }
}
