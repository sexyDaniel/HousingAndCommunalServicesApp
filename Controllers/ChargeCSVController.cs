using GKU_App.CSVParsing.Interfaces;
using GKU_App.Exceptions;
using GKU_App.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ChargeCSVController : Controller
    {
        private IParseCharge parse;

        public ChargeCSVController(IParseCharge parse)
        {
            this.parse = parse;
        }

        [HttpPost]
        public bool AddNewCSV(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    uploadedFile.CopyToAsync(stream);
                }
                parse.ParsingCharge(filePath);
                return true;
            }
            else
            {
                Log log = new Log();
                log.Error(new CSVLoadException("Error loading CSV file "));
                return false;
            }
        }
    }
}
