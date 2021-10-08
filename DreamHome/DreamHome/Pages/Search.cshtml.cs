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
    public class SearchModel : PageModel
    {
        private readonly DreamHome.Data.DreamHomeContext _context;

        public SearchModel(DreamHome.Data.DreamHomeContext context)
        {
            _context = context;
        }

        public IList<Apartment> Apartment { get; set; }

        public bool SearchCompleted { get; set; }
        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;
            if (!string.IsNullOrWhiteSpace(query))
            {
                SearchCompleted = true;
                Apartment = await _context.Apartment
                        .Where(x => x.ApartmentName.StartsWith(query))
                        .ToListAsync();
            }
            else
            {
                SearchCompleted = false;
                Apartment = new List<Apartment>();
            }


        }
    }
}

