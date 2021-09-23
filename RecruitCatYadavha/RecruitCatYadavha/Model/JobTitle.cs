using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatYadavha.wwwroot.Model
{

    public class JobTitle
    {
        public int JobTitleId { get; set; }
        [DisplayName("Job Title")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [DisplayName("Minimum Salary")]
        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        public decimal MinimumSalary { get; set; }
        [DisplayName("Maximum Salary")]
        [Range(1000, 500000)]
        [DataType(DataType.Currency)]
        public decimal MaximumSalary { get; set; }
        [DisplayName("Number of Positions")]
        [Required]
        [Range(0,1)]
        public int? NoOfPosition { get; set; }
        [DisplayName("Department Name")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string DepartmentName { get; set; }
        public List<Candidate> Candidates { get; set; }
        public List<Company> Companies { get; set; }
       
    }

}
