using Showroom.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Showroom.ViewModels.Account
{
    public class MyAccountVM
    {
        public User UserId { get; set; }
        public int CarId { get; set; }


    public List<Car>? Items { get; set; }

    }
}
