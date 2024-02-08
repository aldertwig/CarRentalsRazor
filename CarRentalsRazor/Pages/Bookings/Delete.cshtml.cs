using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public Booking Booking { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public DeleteModel(CarRentalsRazor.Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                ErrorMessage = "Delete booking failed.";
                return Page();
            }

            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null)
            {
                ErrorMessage = "Delete booking failed. Booking not found.";
                return Page();
            }
            else 
            {
                Booking = booking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                ErrorMessage = "Delete booking failed.";
                return Page();
            }
            var booking = await _context.Bookings.FindAsync(id);

            if (booking != null)
            {
                Booking = booking;
                _context.Bookings.Remove(Booking);
                var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == booking.CarId);
                if (car != null)
                {
                    car.Available = true;
                    _context.Attach(car).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            TempData["SuccessMessage"] = "Booking deleted successfully.";
            return RedirectToPage("./Index");
        }
    }
}
