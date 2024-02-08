using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IList<Customer> Customer { get;set; } = default!;

        public IndexModel(Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
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
