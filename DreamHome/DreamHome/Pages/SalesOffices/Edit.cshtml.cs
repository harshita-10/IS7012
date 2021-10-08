using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DreamHome.Data;
using DreamHome.Models;

namespace DreamHome.Pages.SalesOffices
{
    public class EditModel : PageModel
    {
        private readonly DreamHome.Data.DreamHomeContext _context;

        public EditModel(DreamHome.Data.DreamHomeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesOffice SalesOffice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOffice = await _context.SalesOffice.FirstOrDefaultAsync(m => m.SalesOfficeId == id);

            if (SalesOffice == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // CHECK BUILT-IN VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
            if (!ModelState.IsValid)
            {
                return Page();
            }


            // CHECK SALES DATE CANNOT BE IN PAST
            var Date = SalesOffice.SalesDate;
            var latestdate = DateTime.Now;
            if (latestdate < Date)
            {
                ModelState.AddModelError("SalesOffice.SalesDate", "Sales Date Cannot be in Future");
            }
            // CHECK AGAIN AFTER CUSTOM VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
            if (!ModelState.IsValid)
            {
                return Page();
            }
           

            _context.Attach(SalesOffice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOfficeExists(SalesOffice.SalesOfficeId))
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

        private bool SalesOfficeExists(int id)
        {
            return _context.SalesOffice.Any(e => e.SalesOfficeId == id);
        }
    }
}
