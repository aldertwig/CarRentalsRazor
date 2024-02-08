using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Bookings
{
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public Booking Booking { get; set; } = default!; 
        public string ErrorMessage { get; set; } = string.Empty;

        public DetailsModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                ErrorMessage = "Detailing booking failed.";
                return Page();
            }

            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null)
            {
                ErrorMessage = "Detailing booking failed. Booking not found.";
                return Page();
            }
            else 
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
