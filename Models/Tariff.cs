using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class Tariff
    {
        public int ServiceId { get; set; }
        public int BuildingId { get; set; }
        public Service Service { get; set; }

        public Building Building { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public DateTime BeginDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
