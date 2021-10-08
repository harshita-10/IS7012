using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHome.Models
{
    public class City
    {
        public int CityId { get; set; }
        [DisplayName("City Name")]
        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
        public List<Apartment> Apartments { get; set; }

    }
}
