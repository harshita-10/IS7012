﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DreamHome.Data;
using DreamHome.Models;

namespace DreamHome.Pages.Apartments
{
    public class UpdateAvailabilityModel : PageModel
    {
        private readonly DreamHome.Data.DreamHomeContext _context;

        public UpdateAvailabilityModel(DreamHome.Data.DreamHomeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Apartment Apartment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apartment = await _context.Apartment
               .Include(a => a.Agent)
               .Include(a => a.City).FirstOrDefaultAsync(m => m.ApartmentId == id);

            if (Apartment == null)
            {
                return NotFound();
            }
           //ViewData["AgentId"] = new SelectList(_context.Agent, "AgentId", "AgentFirstName");
           //ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var account = await _context.Apartment.FindAsync(Apartment.ApartmentId);
            account.Availability = true;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Apartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(Apartment.ApartmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartment.Any(e => e.ApartmentId == id);
        }
    }
}
