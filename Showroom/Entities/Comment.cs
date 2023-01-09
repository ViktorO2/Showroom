using System.ComponentModel.DataAnnotations.Schema;

namespace Showroom.Entities
{
    public class Comment:BaseEntity
    {
        public string Name { get; set; }
   
        public int UserId { get; set; }

        public int CarId { get; set; }

      
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
    }
}
