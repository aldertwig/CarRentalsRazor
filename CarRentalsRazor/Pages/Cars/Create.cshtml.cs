using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public Car Car { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public CreateModel(Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Cars == null || Car == null)
            {
                ErrorMessage = "Create car failed.";
                return Page();
            }

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Car created successfully.";
            return RedirectToPage("./Index");
        }
    }
}
