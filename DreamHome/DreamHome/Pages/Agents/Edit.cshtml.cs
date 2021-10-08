using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DreamHome.Data;
using DreamHome.Models;

namespace DreamHome.Pages.Agents
{
    public class EditModel : PageModel
    {
        private readonly DreamHome.Data.DreamHomeContext _context;

        public EditModel(DreamHome.Data.DreamHomeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Agent Agent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Agent = await _context.Agent
                .Include(a => a.SalesOffice).FirstOrDefaultAsync(m => m.AgentId == id);

            if (Agent == null)
            {
                return NotFound();
            }
           ViewData["SalesOfficeId"] = new SelectList(_context.Set<SalesOffice>(), "SalesOfficeId", "OfficeName");
            return Page();
        }

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
            var Phone = Agent.AgentPhoneNumber;
            var currentId = Agent.AgentId;
            bool PhoneAlreadyExists = await _context.Agent.AnyAsync(x => x.AgentPhoneNumber == Phone && x.AgentId != currentId);

            if (PhoneAlreadyExists)
            {
                ModelState.AddModelError("Agent.AgentPhoneNumber", "Phone Number Already Exists");
            }
            ViewData["SalesOfficeId"] = new SelectList(_context.Set<SalesOffice>(), "SalesOfficeId", "OfficeName");
            // CHECK AGAIN AFTER CUSTOM VALIDATION RULES AND RETURN PAGE IF ERRORS FOUND
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Agent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(Agent.AgentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AgentExists(int id)
        {
            return _context.Agent.Any(e => e.AgentId == id);
        }
    }
}
