using GKU_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.GetCharge.Interfaces
{
    public interface IChargeCalculation
    {
        public Property GetProperty(int ownerId);
        public List<Charge> GetCharge(int PropertyId, DateTime StartDate, DateTime EndDate);
    }
}
