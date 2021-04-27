using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }

        public Owner Owner { get; set; }
        public int OwnerId { get; set; }

        [Required]
        [MaxLength(30)]
        public double Square { get; set; }

        [Required]
        [MaxLength(30)]
        public int ApartmentNumber { get; set; }

        public Building Building { get; set; }
        public int BuildingId { get; set; }
    }
}
