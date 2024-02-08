using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public Customer Customer { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public DeleteModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                ErrorMessage = "Delete customer failed.";
                return Page();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null)
            {
                ErrorMessage = "Delete customer failed. Customer not found.";
                return Page();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                ErrorMessage = "Delete customer failed.";
                return Page();
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                Customer = customer;
                _context.Customers.Remove(Customer);
                await _context.SaveChangesAsync();
            }

            TempData["SuccessMessage"] = "Customer deleted successfully.";
            return RedirectToPage("./Index");
        }
    }
}
