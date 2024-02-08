using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public Customer Customer { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public CreateModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Customers == null || Customer == null)
            {
                ErrorMessage = "Create customer failed.";
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Customer created successfully.";
            return RedirectToPage("./Index");
        }
    }
}
