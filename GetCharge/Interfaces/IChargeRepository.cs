using GKU_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.GetCharge.Interfaces
{
    public interface IChargeRepository
    {
        public Dictionary<Charge, Tariff> GetCharge(int ownerId, DateTime StartDate, DateTime EndDate);
    }
}
