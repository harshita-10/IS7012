using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHome.Models
{
    public class Agent
    {
        public int AgentId { get; set; }
        [DisplayName("First Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string AgentFirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [StringLength(50 , MinimumLength = 3)]
        public string AgentLastName { get; set; }
        [DisplayName("Full Name")]
        public string FullName
        {
            get { return $"{AgentFirstName} {AgentLastName}"; }
        }
        [DisplayName("Phone Number")]
        [Required]
        [Phone]
        [StringLength(10)]

        public string AgentPhoneNumber { get; set; }
        [DisplayName("Brokerage Cost")]
        [Range(-200, 1000000)]
        [DataType(DataType.Currency)]
        public decimal BrokerageCost { get; set; }
        [DisplayName("Sales Office")]
        public SalesOffice SalesOffice { get; set; }
        [DisplayName("Sales Office")]
        public int SalesOfficeId { get; set; }
        public List<Apartment> Apartments { get; set; }
       

    }
}
