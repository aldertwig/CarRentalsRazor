using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public Booking Booking { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public EditModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                ErrorMessage = "Edit booking failed.";
                return Page();
            }

            var booking =  await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null)
            {
                ErrorMessage = "Edit booking failed. Booking not found";
                return Page();
            }
            Booking = booking;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Edit booking failed.";
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.CarId))
                {
                    ErrorMessage = "Edit booking failed. Booking not found";
                    return Page();
                }
                else
                {
                    throw;
                }
            }
            TempData["SuccessMessage"] = "Booking edited successfully.";
            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
          return (_context.Bookings?.Any(b => b.Id == id)).GetValueOrDefault();
        }
    }
}
