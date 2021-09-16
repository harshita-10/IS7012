using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatYadavha.wwwroot.Model
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public decimal TargetSalary { get; set; }
        public DateTime? StartDate { get; set; }
        public int? SSN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }
        public int? IndustryId { get; set; }
        public Industry Industry { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

    }

}
