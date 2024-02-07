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
    public class DeleteModel : PageModel
    {
        private readonly CarRentalsRazor.Data.ApplicationDbContext _context;

        public DeleteModel(CarRentalsRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CarPicture CarPicture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CarPictures == null)
            {
                return NotFound();
            }

            var carpicture = await _context.CarPictures.FirstOrDefaultAsync(m => m.Id == id);

            if (carpicture == null)
            {
                return NotFound();
            }
            else 
            {
                CarPicture = carpicture;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CarPictures == null)
            {
                return NotFound();
            }
            var carpicture = await _context.CarPictures.FindAsync(id);

            if (carpicture != null)
            {
                CarPicture = carpicture;
                _context.CarPictures.Remove(CarPicture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
