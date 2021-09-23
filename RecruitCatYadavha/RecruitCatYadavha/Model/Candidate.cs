using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace RecruitCatYadavha.wwwroot.Model
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        [DisplayName("First Name")]
        [StringLength(20, MinimumLength = 3)]

        [Required]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Target Salary")]
        [Range(1 , 50000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TargetSalary { get; set; }
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        
        
        [DisplayName("Social Security Number")]
        [StringLength(11)]
        [RegularExpression("^\\d{3}-?\\d{2}-?\\d{4}$")]
        public string SSN { get; set; }
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Job Title")]
        public JobTitle JobTitle { get; set; }
        [DisplayName("Job Title")]
        public int JobTitleId { get; set; }
        [DisplayName("Industry")]
        public Industry Industry { get; set; }
        public int IndustryId { get; set; }
        [DisplayName("Company")]
        public Company Company { get; set; }
        public int? CompanyId { get; set; }
       
    }

}
