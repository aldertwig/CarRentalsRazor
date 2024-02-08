using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public IList<Booking> Booking { get;set; } = default!;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            if (_context.Bookings != null)
            {
                if (CurrentUser.IsAdmin)
                {
                    Booking = await _context.Bookings.ToListAsync();
                } 
                else
                {
                    Booking = await _context.Bookings.Where(b => b.Email == CurrentUser.Email).ToListAsync();
                }
            }
        }
    }
}
