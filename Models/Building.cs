using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Street { get; set; }

        [Required]
        [MaxLength(30)]
        public string BuildingNumber { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        public List<ServiceCompany> ServiceCompanies { get; set; } = new List<ServiceCompany>();

        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
