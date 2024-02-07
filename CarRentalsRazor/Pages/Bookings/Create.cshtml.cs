using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalsRazor.Data;
using CarRentalsRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalsRazor.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly CarRentalsRazor.Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public Booking Booking { get; set; } = default!;
        public int? CarId { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public CreateModel(CarRentalsRazor.Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        //public IActionResult OnGetAsync(int id)
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            CarId = car.Id;
            CurrentUser.LastCarLookedAtId = car.Id;
            //_httpContextAccessor.HttpContext.Response.Cookies.Append("BookingCarId", car.Id.ToString());
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

            return RedirectToPage("./Index");
        }
    }
}
