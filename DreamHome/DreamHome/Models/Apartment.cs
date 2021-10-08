using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHome.Models
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        [DisplayName("Apartment Name")]
        [Required]
        [StringLength(50)]
        public string ApartmentName { get; set; }
        [DisplayName("Availability")]
        public bool Availability { get; set; }
        [DisplayName("Market Price")]
        [Range(-200, 1000000)]
        [DataType(DataType.Currency)]
        public decimal MarketPrice { get; set; }
        [DisplayName("Floor Number")]
        [Range(0, 7)]
        public int FloorNumber { get; set; }
        [DisplayName("Booking Amount")]
        [Range(0, 500)]
        [DataType(DataType.Currency)]
        public decimal BookingAmount { get; set; }
        [DisplayName("Date of Availability")]
        [DataType(DataType.Date)]
        public DateTime? AvailabilityDate { get; set; }
        [DisplayName("Agent")]
        public Agent Agent { get; set; }
        [DisplayName("Agent")]
        public int AgentId { get; set; }
        [DisplayName("City")]
        public City City { get; set; }
        [DisplayName("City")]
        public int CityId { get; set; }

        [DisplayName("Available From at Booking Amount")]
        public string AvailableFrom
        {
            get { return $"{AvailabilityDate} {BookingAmount}"; }
        }
    }
}
