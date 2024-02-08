using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public Car Car { get; set; } = default!; 
        public string ErrorMessage { get; set; } = string.Empty;

        public DetailsModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                ErrorMessage = "Detailing car failed.";
                return Page();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                ErrorMessage = "Detailing car failed. Car not found.";
                return Page();
            }
            else 
            {
                Car = car;
            }
            return Page();
        }
    }
}
