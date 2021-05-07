using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models.Requests
{
    public class AdminAuthRequest
    {
        public string Password { get; set; }
        public string Login { get; set; }
    }
}
