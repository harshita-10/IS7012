using DreamHome.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHome.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DreamHomeContext _context;

        public IndexModel(ILogger<IndexModel> logger, DreamHome.Data.DreamHomeContext context)
        
        {
            _logger = logger;
            _context = context;
        }
      
        public int TotalApartments { get; set; }
       public decimal AverageBookingAmount { get; set; }
        public int TransactionsToday { get; set; }

        public async Task OnGetAsync()
        {
           TotalApartments = await _context.Apartment.CountAsync();
           
            AverageBookingAmount = await _context.Apartment.AverageAsync(x => x.BookingAmount);
            TransactionsToday = await _context.SalesOffice.CountAsync(x => x.SalesDate >= DateTime.Today);

        }
    }
}
