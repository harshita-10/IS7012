using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamHome.Data;
using DreamHome.Models;

namespace DreamHome.Pages.Apartments
{
    public class DeleteModel : PageModel
    {
        private readonly DreamHome.Data.DreamHomeContext _context;

        public DeleteModel(DreamHome.Data.DreamHomeContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apartment = await _context.Apartment.FindAsync(id);

            if (Apartment != null)
            {
                _context.Apartment.Remove(Apartment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
