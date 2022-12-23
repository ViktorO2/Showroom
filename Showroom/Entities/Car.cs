using System.ComponentModel.DataAnnotations;

namespace Showroom.Entities
{
    public class Car : BaseEntity
    {
        public string CarName { get; set; }

        public string CarDescription { get; set; }

        public string CarPictureURL { get; set; }

        public bool IsAvailable { get; set; }

    }
}
