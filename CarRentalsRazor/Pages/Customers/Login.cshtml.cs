using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarRentalsRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalsRazor.Pages.Customers
{
    public class LoginModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        [BindProperty]
        public LoginRequest LoginRequest { get; set; } = default!;
        [BindProperty]
        public Customer Customer { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int CarId { get; set; }
        public string LoginErrorMessage { get; set; } = string.Empty;
        public string RegisterErrorMessage { get; set; } = string.Empty;

        public LoginModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            if (string.IsNullOrEmpty(LoginRequest.Email) || string.IsNullOrEmpty(LoginRequest.Password) || _context.Customers == null)
            {
                ModelState.AddModelError("LoginRequest", "This field is required.");
                LoginErrorMessage = "Login request failed.";
                return Page();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == LoginRequest.Email);
            if (customer == null)
            {
                LoginErrorMessage = "Login request failed. No user with email " + LoginRequest.Email + " exists.";
                return Page();
            }
            if (customer.Password != LoginRequest.Password)
            {
                LoginErrorMessage = "Login request failed. Wrong password.";
                return Page();
            }

            CurrentUser.Email = customer.Email;
            CurrentUser.IsLoggedIn = true;

            if (CurrentUser.RedirectedFromBooking)
            {
                CurrentUser.RedirectedFromBooking = false;
                return RedirectToPage("/Bookings/Create", new { id = CurrentUser.LastCarLookedAtId.ToString()});
            }

            return RedirectToPage("/Cars/Index");
        }

        public async Task<IActionResult> OnPostRegisterAsync()
        {
            if (string.IsNullOrEmpty(Customer.FirstName) || string.IsNullOrEmpty(Customer.LastName) ||
                string.IsNullOrEmpty(Customer.Email) || string.IsNullOrEmpty(Customer.Password) ||
                _context.Customers == null || Customer == null)
            {
                ModelState.AddModelError("Customer", "This field is required.");
                return Page();
            }
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == Customer.Email);
            if (customer != null)
            {
                RegisterErrorMessage = "Registering failed. A user with email " + Customer.Email + " already exists.";
                return Page();
            }
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            CurrentUser.Customer = Customer;
            CurrentUser.Email = Customer.Email;
            CurrentUser.IsLoggedIn = true;

            if (CurrentUser.RedirectedFromBooking)
            {
                CurrentUser.RedirectedFromBooking = false;
                return RedirectToPage("/Bookings/Create", new { id = CurrentUser.LastCarLookedAtId.ToString() });
            }

            return RedirectToPage("/Cars/Index");
        }
    }
}
