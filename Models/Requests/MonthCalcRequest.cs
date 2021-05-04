using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models.Requests
{
    public class MonthCalcRequest
    {
        public int PersonalId { get; set; }
        public DateTime Date { get; set; }
    }
}
