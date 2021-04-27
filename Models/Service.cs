using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<ServiceCompany> ServiceCompanies { get; set; } = new List<ServiceCompany>();
    }
}
