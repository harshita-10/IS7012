using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHome.Models
{
    public class SalesOffice
    {
        public int SalesOfficeId { get; set; }
        [DisplayName("Office Name")]
        [Required]
        [StringLength(50)]
        public string OfficeName { get; set; }
        [DisplayName("Last Sales Date")]
        [DataType(DataType.Date)]
        public DateTime SalesDate { get; set; }
        public List<Agent> Agents { get; set; }

    }
}
