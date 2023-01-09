using Showroom.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Showroom.ViewModels.Cars
{
    public class CreateVM
    {
        public int CarId { get; set; }

        [DisplayName("Car Brand: ")]
        [Required(ErrorMessage= " * This field is Required!")]
        public string CarName { get; set; }
       
        [DisplayName("Description: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string CarDescription { get; set; }
       
        [DisplayName("Photo: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string CarPictureURL { get; set; }

        [DisplayName("Is Available: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public bool IsAvailable { get; set; }

   
    }
}
