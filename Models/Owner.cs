using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class Owner
    {
        [Key]
        public int PersonalAccount { get; set; }
        [Required]
        [MaxLength(30)]
        public int FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public int LastName { get; set; }
        [MaxLength(30)]
        [Required]
        public int Patronymic { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
