using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DreamHome.Models;

namespace DreamHome.Data
{
    public class DreamHomeContext : DbContext
    {
        public DreamHomeContext (DbContextOptions<DreamHomeContext> options)
            : base(options)
        {
        }

        public DbSet<DreamHome.Models.Agent> Agent { get; set; }

        public DbSet<DreamHome.Models.Apartment> Apartment { get; set; }

        public DbSet<DreamHome.Models.City> City { get; set; }

        public DbSet<DreamHome.Models.SalesOffice> SalesOffice { get; set; }
    }
}
