using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Showroom.Entities;
using Showroom.ExtentionMethods;
using Showroom.Repositories;
using Showroom.ViewModels.Cars;


namespace Showroom.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index(IndexVM model)
        {

            User loggedUser = this.HttpContext.Session.Get<User>("loggedUser");
            CarsRepository repo=new CarsRepository();
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
            User loggedUser = this.HttpContext.Session.Get<User>("loggedUser");

                if(!ModelState.IsValid)
                return View(model);
     
            Car item = new Car();
            item.Id = model.CarId;
            item.CarName = model.CarName;
            item.CarDescription = model.CarDescription;
            item.CarPictureURL= model.CarPictureURL;
            item.IsAvailable = model.IsAvailable;
           
            CarsRepository repo = new CarsRepository();
            repo.Save(item);

            return RedirectToAction("Index", "Cars");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CarsRepository repo = new CarsRepository();
            User loggedUser = this.HttpContext.Session.Get<User>("loggedUser");
            Car item=repo.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return RedirectToAction("Index", "Cars");

            EditVM model = new EditVM();
            model.CarId = item.Id;
            model.CarName = item.CarName;
            model.CarDescription = item.CarDescription;
            model.CarPictureURL = item.CarPictureURL;
            model.IsAvailable = item.IsAvailable;

            return View(model);


        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            User loggedUser = this.HttpContext.Session.Get<User>("loggedUser");
          
            CarsRepository repo = new CarsRepository();
            Car item = repo.FirstOrDefault(p => p.Id == model.CarId);


            if (item.Id != loggedUser.Id)
            {
                ModelState.AddModelError("summaryError", "Owner impersonation attempt detected!");
                return View(model);
            }

            if (model.CarId != loggedUser.Id)
            {
                ModelState.AddModelError("summaryError", "Owner impersonation attempt detected!");
                return View(model);
            }

            model.CarId = item.Id;
            model.CarName = item.CarName;
            model.CarDescription = item.CarDescription;
            model.CarPictureURL = item.CarPictureURL;
            model.IsAvailable= item.IsAvailable; 
            

            repo.Save(item);
            return View(model);


        }

        public IActionResult Delete(int id)
        {
            CarsRepository repo = new CarsRepository();
            Car item = new Car();
        item.Id=id;
            repo.Delete(item);

            return RedirectToAction("Index", "Cars");
        }
    }
}
