using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public Car Car { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public EditModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                ErrorMessage = "Edit car failed.";
                return Page();
            }

            var car =  await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                ErrorMessage = "Edit car failed. Car not found.";
                return Page();
            }
            Car = car;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Edit car failed.";
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
                {
                    ErrorMessage = "Edit car failed. Car not found.";
                    return Page();
                }
                else
                {
                    throw;
                }
            }
            TempData["SuccessMessage"] = "Car edited successfully.";
            return RedirectToPage("./Index");
        }

        private bool CarExists(int id)
        {
          return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
