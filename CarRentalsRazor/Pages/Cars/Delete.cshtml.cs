using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public Car Car { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public DeleteModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                ErrorMessage = "Delete car failed.";
                return Page();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                ErrorMessage = "Delete car failed. Car not found.";
                return Page();
            }
            else 
            {
                Car = car;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                ErrorMessage = "Delete car failed.";
                return Page();
            }
            var car = await _context.Cars.FindAsync(id);

            if (car != null)
            {
                Car = car;
                _context.Cars.Remove(Car);
                await _context.SaveChangesAsync();
            }
            TempData["SuccessMessage"] = "Car deleted successfully.";
            return RedirectToPage("./Index");
        }
    }
}
