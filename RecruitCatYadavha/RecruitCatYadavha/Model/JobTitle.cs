using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatYadavha.wwwroot.Model
{

    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string Title { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public int? NoOfPosition { get; set; }
        public string DepartmentName { get; set; }
        public List<Candidate> Candidates { get; set; }
        public List<Company> Companies { get; set; }

    }

}
