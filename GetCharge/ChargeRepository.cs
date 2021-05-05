using GKU_App.DataBaseContext;
using GKU_App.GetCharge.Interfaces;
using GKU_App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.GetCharge
{
    public class ChargeRepository : IChargeRepository
    {
        private AppDbContext dbContext;

        public ChargeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Property GetProperty(int ownerId)
        {
            return dbContext.Properties.FirstOrDefault(p => p.OwnerId == ownerId);
        }

        public List<Charge> GetCharge(int PropertyId, DateTime StartDate, DateTime EndDate)
        {
            var charges = dbContext.Charges.Where(c => c.PropertyId == PropertyId &&
                c.ChargeDate > StartDate && c.ChargeDate < EndDate);
            return charges.ToList();
        }
    }
}
