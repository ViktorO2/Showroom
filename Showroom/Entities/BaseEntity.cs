using System.ComponentModel.DataAnnotations;

namespace Showroom.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
