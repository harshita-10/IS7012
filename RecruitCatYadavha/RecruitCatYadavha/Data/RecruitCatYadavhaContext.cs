using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitCatYadavha.wwwroot.Model;

namespace RecruitCatYadavha.Data
{
    public class RecruitCatYadavhaContext : DbContext
    {
        public RecruitCatYadavhaContext (DbContextOptions<RecruitCatYadavhaContext> options)
            : base(options)
        {
        }

        public DbSet<RecruitCatYadavha.wwwroot.Model.Candidate> Candidate { get; set; }

        public DbSet<RecruitCatYadavha.wwwroot.Model.Company> Company { get; set; }

        public DbSet<RecruitCatYadavha.wwwroot.Model.Industry> Industry { get; set; }

        public DbSet<RecruitCatYadavha.wwwroot.Model.JobTitle> JobTitle { get; set; }
    }
}
