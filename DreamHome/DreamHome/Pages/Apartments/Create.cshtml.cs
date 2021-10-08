using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DreamHome.Data;
using DreamHome.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamHome.Pages.Apartments
{
    public class CreateModel : PageModel
    {
        private readonly DreamHome.Data.DreamHomeContext _context;

        public CreateModel(DreamHome.Data.DreamHomeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AgentId"] = new SelectList(_context.Agent, "AgentId", "FullName");
        ViewData["CityId"] = new SelectList(_context.Set<City>(), "CityId", "CityName");

            return Page();
        }

        [BindProperty]
        public Apartment Apartment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // CHECK BUILT-IN VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // CHECK THE AVAILABLE DATE CANNOT BE IN PAST
            var AD = Apartment.AvailabilityDate;
            var TodayDate = DateTime.Now;
            if (AD < TodayDate)
            {
                ModelState.AddModelError("Apartment.AvailabilityDate", "Date cannot be in past");
            }
            ViewData["AgentId"] = new SelectList(_context.Agent, "AgentId", "FullName");
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "CityId", "CityName");

            // CHECK AGAIN AFTER CUSTOM VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Apartment.Add(Apartment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
