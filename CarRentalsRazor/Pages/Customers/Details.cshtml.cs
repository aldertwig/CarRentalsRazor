using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;
        public Customer Customer { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public DetailsModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                ErrorMessage = "Detailing customer failed.";
                return Page();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                ErrorMessage = "Detailing customer failed. Customer not found.";
                return Page();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
