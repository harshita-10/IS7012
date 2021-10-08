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
    public class IndexModel : PageModel
    {
        private readonly DreamHome.Data.DreamHomeContext _context;

        public IndexModel(DreamHome.Data.DreamHomeContext context)
        {
            _context = context;
        }

        public IList<Apartment> Apartment { get;set; }

        public async Task OnGetAsync()
        {
            Apartment = await _context.Apartment
                .Include(a => a.Agent)
                .Include(a => a.City).ToListAsync();
        }
    }
}
