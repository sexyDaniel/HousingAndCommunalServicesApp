using GKU_App.DataBaseContext;
using GKU_App.Exceptions;
using GKU_App.GetCharge.Interfaces;
using GKU_App.Logger;
using GKU_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ChargeController : Controller
    {
        private IChargeRepository ownerCharge;
        public ChargeController(IChargeRepository ownerCharge, AppDbContext dbContext)
        {
            this.ownerCharge = ownerCharge;
        }


        [HttpPost]
        public List<ChargeAnswer> GetChargesByDate(ChargeRequestData data)
        {
            Dictionary<Charge, Tariff> charges;
            List<ChargeAnswer> answer = new List<ChargeAnswer>();
            Log log = new Log();

            if (HttpContext.Request.Cookies.TryGetValue("currentOwner", out string currentOwner))
            {
                Property property = ownerCharge.GetProperty(Convert.ToInt32(currentOwner));
                charges = ownerCharge.GetCharge(property.PropertyId, data.StartDate, data.EndDate);
                foreach (KeyValuePair<Charge, Tariff> keyValue in charges)
                {
                    answer.Add(new ChargeAnswer(keyValue.Key, keyValue.Value));
                }
            }
            else
            {
                log.Error(new CookieEmptyException("User authorization failed! Unable to send request to server."));
                answer = null;
            }

            return answer;
        }
    }
}
