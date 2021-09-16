using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatYadavha.wwwroot.Model
{

    public class Industry
    {
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public int NumberOfCompanies { get; set; }
        public List<Candidate> Candidates { get; set; }
        public List<Company> Companies { get; set; }

    }



}
