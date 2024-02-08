﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IList<Car> Car { get;set; } = default!;

        public IndexModel(Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnGetAsync()
        {
            if (_context.Cars != null)
            {
                if (CurrentUser.IsAdmin)
                {
                    Car = await _context.Cars.ToListAsync();
                }
                else
                {
                    Car = await _context.Cars.Where(c => c.Available == true).ToListAsync();
                }
            }
        }
    }
}
