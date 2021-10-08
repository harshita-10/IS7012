using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DreamHome.Data;
using DreamHome.Models;

namespace DreamHome.Pages.SalesOffices
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
            return Page();
        }

        [BindProperty]
        public SalesOffice SalesOffice { get; set; }

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
            if(latestdate<Date)
            {
                ModelState.AddModelError("SalesOffice.SalesDate", "Sales Date cannot Future");
            }
            // CHECK AGAIN AFTER CUSTOM VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SalesOffice.Add(SalesOffice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
