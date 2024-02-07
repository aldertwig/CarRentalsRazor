using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRentalsRazor.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public string Email { get; set; }
        [Required]
        public DateTime RentalStart { get; set; }
        [Required]
        public DateTime RentalEnd { get; set; }
    }
}
