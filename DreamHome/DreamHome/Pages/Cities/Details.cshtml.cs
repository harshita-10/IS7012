using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamHome.Data;
using DreamHome.Models;

namespace DreamHome.Pages.Cities
{
    public class DetailsModel : PageModel
    {
        private readonly DreamHome.Data.DreamHomeContext _context;

        public DetailsModel(DreamHome.Data.DreamHomeContext context)
        {
            _context = context;
        }

        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City
                .Include(c => c.Apartments).FirstOrDefaultAsync(m => m.CityId == id);


            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
