using System.ComponentModel.DataAnnotations.Schema;

namespace Showroom.Entities
{
    public class RentCars:BaseEntity
    {
        public int UserId { get; set; }
        public int CarId { get; set; }


        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }


    }
}
