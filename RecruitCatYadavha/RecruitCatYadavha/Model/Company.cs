using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatYadavha.wwwroot.Model
{

    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string PostionName { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        public DateTime OptionalStartDate { get; set; }
        public string Location { get; set; }
        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }
        public List<Candidate> Candidates { get; set; }

    }

}
