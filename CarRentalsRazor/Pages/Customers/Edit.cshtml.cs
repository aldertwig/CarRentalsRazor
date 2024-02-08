using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public Customer Customer { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public EditModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                ErrorMessage = "Edit customer failed.";
                return Page();
            }

            var customer =  await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                ErrorMessage = "Edit customer failed. Customer not found.";
                return Page();
            }
            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Edit customer failed. Model state is not valid.";
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.Id))
                {
                    ErrorMessage = "Edit customer failed. Customer not found.";
                    return Page();
                }
                else
                {
                    throw;
                }
            }

            TempData["SuccessMessage"] = "Customer edited successfully.";
            return RedirectToPage("./Index");
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
