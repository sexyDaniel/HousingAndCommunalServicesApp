using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class Charge
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int PropertyId { get; set; }
        public Service Service { get; set; }
        public Property Property { get; set; }

        [Required]
        public DateTime ChargeDate { get; set; }

        [Required]
        public double Volume { get; set; }
    }
}
