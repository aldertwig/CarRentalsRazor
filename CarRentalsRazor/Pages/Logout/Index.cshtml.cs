using CarRentalsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalsRazor.Pages.Logout
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult OnGet()
        {
            CurrentUser.Email = "";
            CurrentUser.IsLoggedIn = false;
            CurrentUser.IsAdmin = false;
            CurrentUser.Admin = null;
            CurrentUser.Customer = null;

            return RedirectToPage("/Index");
        }
    }
}
