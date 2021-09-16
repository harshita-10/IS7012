using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatYadavha.Data;
using RecruitCatYadavha.wwwroot.Model;

namespace RecruitCatYadavha.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly RecruitCatYadavha.Data.RecruitCatYadavhaContext _context;

        public IndexModel(RecruitCatYadavha.Data.RecruitCatYadavhaContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; }

        public async Task OnGetAsync()
        {
            Company = await _context.Company
                .Include(c => c.Industry)
                .Include(c => c.JobTitle).ToListAsync();
        }
    }
}
