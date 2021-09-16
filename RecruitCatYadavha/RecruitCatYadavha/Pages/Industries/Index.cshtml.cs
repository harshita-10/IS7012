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
    public class IndexModel : PageModel
    {
        private readonly RecruitCatYadavha.Data.RecruitCatYadavhaContext _context;

        public IndexModel(RecruitCatYadavha.Data.RecruitCatYadavhaContext context)
        {
            _context = context;
        }

        public IList<Industry> Industry { get;set; }

        public async Task OnGetAsync()
        {
            Industry = await _context.Industry.ToListAsync();
        }
    }
}
