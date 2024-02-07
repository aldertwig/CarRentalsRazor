using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Data;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.CarPictures
{
    public class IndexModel : PageModel
    {
        private readonly CarRentalsRazor.Data.ApplicationDbContext _context;

        public IndexModel(CarRentalsRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CarPicture> CarPicture { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CarPictures != null)
            {
                CarPicture = await _context.CarPictures.ToListAsync();
            }
        }
    }
}
