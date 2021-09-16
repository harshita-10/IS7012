using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatYadavha.Data;
using RecruitCatYadavha.wwwroot.Model;

namespace RecruitCatYadavha.Pages.Industries
{
    public class DetailsModel : PageModel
    {
        private readonly RecruitCatYadavha.Data.RecruitCatYadavhaContext _context;

        public DetailsModel(RecruitCatYadavha.Data.RecruitCatYadavhaContext context)
        {
            _context = context;
        }

        public Industry Industry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Industry = await _context.Industry.FirstOrDefaultAsync(m => m.IndustryId == id);

            if (Industry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
