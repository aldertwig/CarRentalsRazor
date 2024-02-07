﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalsRazor.Data;
using CarRentalsRazor.Models;

namespace CarRentalsRazor.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentalsRazor.Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Customer Customer { get; set; } = default!;

        public DetailsModel(CarRentalsRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }
    }
}
