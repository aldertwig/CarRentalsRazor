using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public IList<Customer> Customer { get;set; } = default!;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                if (CurrentUser.IsAdmin)
                {
                    Customer = await _context.Customers.ToListAsync();
                }
                else
                {
                    Customer = await _context.Customers.Where(c => c.Email == CurrentUser.Email).ToListAsync();
                }
            }
        }
    }
}
