using GKU_App.GetCharge;
using GKU_App.GetCharge.Interfaces;
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
        public ChargeController(IChargeRepository ownerCharge)
        {
            this.ownerCharge = ownerCharge;
        }


        [HttpPost]
        public Dictionary<Charge, Tariff> GetChargesByDate(ChargeRequestData data)
        {
            Dictionary<Charge, Tariff> charges;

            if (HttpContext.Request.Cookies.TryGetValue("currentOwner", out string currentOwner))
            {
                Property property = ownerCharge.GetProperty(Convert.ToInt32(currentOwner));
                charges = ownerCharge.GetCharge(property.PropertyId, data.StartDate, data.EndDate);
            }
            else
            {
                charges = null;
            }

            return charges;
        }
    }
}
