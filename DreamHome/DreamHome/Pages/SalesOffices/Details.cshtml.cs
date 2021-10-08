using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamHome.Data;
using DreamHome.Models;

namespace DreamHome.Pages.SalesOffices
{
    public class DetailsModel : PageModel
    {
        private readonly DreamHome.Data.DreamHomeContext _context;

        public DetailsModel(DreamHome.Data.DreamHomeContext context)
        {
            _context = context;
        }

        public SalesOffice SalesOffice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOffice = await _context.SalesOffice
                .Include(c => c.Agents).FirstOrDefaultAsync(m => m.SalesOfficeId == id);

            if (SalesOffice == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
