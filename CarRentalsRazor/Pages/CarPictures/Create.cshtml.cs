using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.CarPictures
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public CarPicture CarPicture { get; set; } = default!;
        public int CarId { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public CreateModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            CarId = id;
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.CarPictures == null || CarPicture == null)
            {
                ErrorMessage = "Add car picture failed.";
                return Page();
            }

            _context.CarPictures.Add(CarPicture);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Car picture added successfully.";
            return RedirectToPage("/Cars/Index");
        }
    }
}
