using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRentalsRazor.Models
{
    public class CarPicture
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        [Required]
        public string PictureUrl { get; set; }
    }
}
