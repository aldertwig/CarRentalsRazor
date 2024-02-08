using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarRentalsRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalsRazor.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public Booking Booking { get; set; } = default!;
        public int? CarId { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public CreateModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //public IActionResult OnGetAsync(int id)
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                ErrorMessage = "Create booking failed.";
                return Page();
            }
            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                ErrorMessage = "Create booking failed. Car not found.";
                return Page();
            }
            CarId = car.Id;
            CurrentUser.LastCarLookedAtId = car.Id;
            if (CurrentUser.IsLoggedIn)
            {
                return Page();
            }
            CurrentUser.RedirectedFromBooking = true;
            return RedirectToPage("/Customers/Login");
        }

        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Bookings == null || Booking == null)
            {
                ErrorMessage = "Create booking failed.";
                return Page();
            }
            _context.Bookings.Add(Booking);

            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == Booking.CarId);
            if (car != null)
            {
                car.Available = false;
                _context.Attach(car).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Booking created successfully.";
            return RedirectToPage("./Index");
        }
    }
}
