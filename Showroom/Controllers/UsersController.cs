using Microsoft.AspNetCore.Mvc;
using Showroom.ActionFilters;
using Showroom.Entities;
using Showroom.Repositories;
using Showroom.ViewModels.Users;
using System.Linq.Expressions;

namespace Showroom.Controllers
{
   
    public class UsersController : Controller
    {
       [HttpGet]
        public IActionResult Index(IndexVM model)
        {
            UsersRepository repo = new UsersRepository();
            model.Items = repo.getAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if(!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            UsersRepository repo = new UsersRepository();
            repo.Save(item);

            return RedirectToAction("Index", "Users");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
          UsersRepository repo=new UsersRepository();
            User item = repo.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return RedirectToAction("Index", "Users");

            EditVM model = new EditVM();
            model.Id = id;
            model.Username = item.Username;
            model.Password = item.Password;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Id = model.Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            UsersRepository repo = new UsersRepository();
            repo.Save(item);

            return RedirectToAction("Index", "Users");
        }
       public IActionResult Delete(int id)
        {
            UsersRepository repo = new UsersRepository();

            User item = new User();
            item.Id = id;
                
            repo.Delete(item);
            return RedirectToAction("Index", "Users");
        }
    }
}
