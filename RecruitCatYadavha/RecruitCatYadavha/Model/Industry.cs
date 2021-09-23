using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatYadavha.wwwroot.Model
{

    public class Industry
    {
        public int IndustryId { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [Required]
        [DisplayName("Industry Name")]
        public string IndustryName { get; set; }
        [Required]
        [Range(1,200000)]
        [DisplayName("Number of Companies")]
        public int NumberOfCompanies { get; set; }
        public List<Candidate> Candidates { get; set; }
        public List<Company> Companies { get; set; }

    }



}
