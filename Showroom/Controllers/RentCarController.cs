using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Showroom.Entities;
using Showroom.ExtentionMethods;
using Showroom.Repositories;
using Showroom.ViewModels.Cars;

namespace Showroom.Controllers
{
    public class RentCarController : Controller
    {
        public IActionResult RentACar(IndexVM model)
        {
            CarsRepository carRepo = new CarsRepository();
            model.Items = carRepo.GetAll<Car>(x => x.IsAvailable == true).Select(x => x).ToList();

            return View(model);
        }

       public IActionResult Rent(int Id)
        {
            RentCarRepository repo = new RentCarRepository();
            CarsRepository carRepo = new CarsRepository();

           var loggedUser= this.HttpContext.Session.Get<User>("loggedUser");  

        var CarForRent=carRepo.FirstOrDefault(x => x.Id == Id);
            if (CarForRent != null)
            {
                var RentedCar = new RentCars()
                {
                    UserId = loggedUser.Id,
                    CarId = Id
                };
                CarForRent.IsAvailable = false;
                carRepo.Save(CarForRent);
                repo.Save(RentedCar);
            }
            return RedirectToAction(nameof(RentACar));
        }




    }
}

