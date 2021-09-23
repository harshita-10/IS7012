using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatYadavha.wwwroot.Model
{

    public class Company
    {
        public int CompanyId { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Required]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("Position Name")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string PostionName { get; set; }
        [DisplayName("Minimum Salary")]
        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        public decimal MinimumSalary { get; set; }
        [DisplayName("Maximum Salary")]
        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        public decimal MaximumSalary { get; set; }
        [DisplayName("Optional Start Date")]
        [DataType(DataType.Date)]
        public DateTime? OptionalStartDate { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [DisplayName("Industry Name")]
        public Industry Industry { get; set; }
        public int IndustryId { get; set; }
        [DisplayName("Job Title")]
        public JobTitle JobTitle { get; set; }
        public int JobTitleId { get; set; }
        public List<Candidate> Candidates { get; set; }

    }

}
