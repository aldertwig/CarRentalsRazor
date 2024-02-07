using CarRentalsRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalsRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            CookieOptions options = new CookieOptions();
            options.Secure = true;
            options.Expires = DateTimeOffset.UtcNow.AddMinutes(10);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("IsLoggedIn", false.ToString());
            _httpContextAccessor.HttpContext.Response.Cookies.Append("UserEmail", "");
            _httpContextAccessor.HttpContext.Response.Cookies.Append("IsAdmin", false.ToString());
        }
    }
}