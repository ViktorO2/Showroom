using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Showroom.Entities;
using Showroom.ExtentionMethods;
using Showroom.Repositories;
using Showroom.ViewModels.Comments;

namespace Showroom.Controllers
{
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(int Id)
        {
            return View();
        }
        [HttpPost]
         public IActionResult Create(CreateVM model,int Id)
        {
            User loggedUser = this.HttpContext.Session.Get<User>("loggedUser");

                if(!ModelState.IsValid)
                return View(model);
     
            Comment item = new Comment();
            item.Name = model.Name;
            item.CarId = Id;
            item.UserId=loggedUser.Id;
            
            
           
            CommentsRepository repo = new CommentsRepository();
            repo.Save(item);

            return RedirectToAction("Index", "Cars");
        }
        

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CommentsRepository repo = new CommentsRepository();
            User loggedUser = this.HttpContext.Session.Get<User>("loggedUser");
            Comment item=repo.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return RedirectToAction("Index", "Cars");

            EditVM model = new EditVM();
            model.Name = item.Name;

            return View(model);


        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            User loggedUser = this.HttpContext.Session.Get<User>("loggedUser");
          
            CommentsRepository repo = new CommentsRepository();
            Comment item = repo.FirstOrDefault(p => p.Id == model.Id);


            if (item.Id != loggedUser.Id)
            {
                ModelState.AddModelError("summaryError", "Owner impersonation attempt detected!");
                return View(model);
            }

            if (model.Id != loggedUser.Id)
            {
                ModelState.AddModelError("summaryError", "Owner impersonation attempt detected!");
                return View(model);
            }

            model.Name = item.Name;

            repo.Save(item);
            return View(model);


        }

        public IActionResult Delete(int id)
        {
            CommentsRepository repo = new CommentsRepository();
            Comment item = repo.FirstOrDefault(p => p.Id == id);
                
            repo.Delete(item);

            return RedirectToAction("Index", "Cars");
        }

    }
}
