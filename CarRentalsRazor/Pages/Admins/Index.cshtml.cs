using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public LoginRequest LoginRequest { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Admins == null)
            {
                ErrorMessage = "Login request failed.";
                return Page();
            }
            if (LoginRequest != null)
            {
                var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == LoginRequest.Email);
                if (admin == null)
                {
                    ErrorMessage = "Login request failed. No user with email " + LoginRequest.Email + " exists.";
                    return Page();
                }
                if (admin.Password != LoginRequest.Password)
                {
                    ErrorMessage = "Login request failed. Wrong password.";
                    return Page();
                }
                CurrentUser.IsAdmin = true;
                CurrentUser.IsLoggedIn = true;
                CurrentUser.Email = admin.Email;
            }

            return RedirectToPage("/Index");
        }
    }
}
