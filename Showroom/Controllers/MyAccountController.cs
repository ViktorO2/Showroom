using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Showroom.Entities;
using Showroom.ExtentionMethods;
using Showroom.Repositories;
using Showroom.ViewModels.Account;

namespace Showroom.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult MyProfile(MyAccountVM model)
        {
            ShowroomDbContext context = new ShowroomDbContext();

            int userId = HttpContext.Session.Get<User>("loggedUser").Id;

            model.UserId = context.Users.FirstOrDefault(u => u.Id == userId);

            model.Items = context.RentCars.Where(c => c.UserId == userId).Select(c => c.Car).ToList();
            

            return View(model);

        }
        public IActionResult UnRent(int id)
        {
            CarsRepository repo = new CarsRepository();
            Car item = new Car();
            item.Id = id;
            repo.Delete(item);

            return RedirectToAction("Index", "Cars");
        }



    }
}
