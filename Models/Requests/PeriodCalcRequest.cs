using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models.Requests
{
    public class PeriodCalcRequest
    {
        public int PersonalId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
    }
}
