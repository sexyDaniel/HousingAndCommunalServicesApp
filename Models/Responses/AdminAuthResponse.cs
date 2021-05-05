using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models.Responses
{
    public class AdminAuthResponse
    {
        public List<string> Errors { get; set; }
        public bool IsSuccessfull => Errors.Count == 0;
        public string Data { get; set; }
    }
}
