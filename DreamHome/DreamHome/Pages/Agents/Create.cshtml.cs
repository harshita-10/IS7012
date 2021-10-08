using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DreamHome.Data;
using DreamHome.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamHome.Pages.Agents
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
        ViewData["SalesOfficeId"] = new SelectList(_context.Set<SalesOffice>(), "SalesOfficeId", "OfficeName");
            return Page();
        }

        [BindProperty]
        public Agent Agent { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            ViewData["SalesOfficeId"] = new SelectList(_context.Set<SalesOffice>(), "SalesOfficeId", "OfficeName");
            // CHECK BUILT-IN VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Phone VALIDATION
            var  Phone= Agent.AgentPhoneNumber;
            bool PhoneAlreadyExists = await _context.Agent.AnyAsync(x => x.AgentPhoneNumber == Phone);

            if (PhoneAlreadyExists)
            {
              ModelState.AddModelError("Agent.AgentPhoneNumber", "Phone number Already Exists");
            }

            
            // CHECK AGAIN AFTER CUSTOM VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Agent.Add(Agent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
