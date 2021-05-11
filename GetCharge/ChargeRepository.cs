using GKU_App.DataBaseContext;
using GKU_App.GetCharge.Interfaces;
using GKU_App.Logger;
using GKU_App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public Dictionary<Charge, Tariff> GetCharge(int ownerId, DateTime StartDate, DateTime EndDate)
        {
            Dictionary<Charge, Tariff> dict = new Dictionary<Charge, Tariff>();


            var charges = dbContext.Charges
                .Include(p => p.Property)
                .ThenInclude(c => c.Building)
                .ThenInclude(c => c.City)
                .Include(p => p.Service)
                .Join(dbContext.Properties, ch => ch.PropertyId, pr => pr.PropertyId, (ch, pr) => new { ch, pr })
                .Where(pr => pr.pr.OwnerId == ownerId && pr.ch.ChargeDate >= StartDate && pr.ch.ChargeDate <= EndDate)
                .Select(pr => pr.ch)
                .ToArray();
            foreach (var charge in charges)
            {
                try
                {
                    var tariff = dbContext.Tariffs.FirstOrDefault(p => p.BuildingId == charge.Property.BuildingId &&
                    p.ServiceId == charge.ServiceId);     
                    dict.Add(charge, tariff);
                }
                catch (Exception e)
                {
                    Log log = new Log();
                    log.ErrorUnique("Failed to request tariff", e);
                }
            }

            return dict;
        }
    }
}
