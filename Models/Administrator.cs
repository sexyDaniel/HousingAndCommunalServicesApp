using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class Administrator
    {
        [Key]
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
