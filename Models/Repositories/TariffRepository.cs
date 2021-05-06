using GKU_App.DataBaseContext;
using GKU_App.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models.Repositories
{
    public class TariffRepository : ITariffRepository
    {
        private AppDbContext context;
        public TariffRepository(AppDbContext context) => this.context = context;

        public List<Tariff> GetTariffs(int personalId)
        {
            var property = context.Properties.FirstOrDefault(p=>p.OwnerId== personalId);
            if (property != null)
            {
                var tariffs = context.Tariffs.Where(t => t.BuildingId == property.BuildingId).ToList();
                foreach (var t in tariffs)
                {
                    var a = context.Services.FirstOrDefault(s => s.ServiceId == t.ServiceId);
                    t.Service = a;
                }
                return tariffs;
            }
            else 
            {
                return null;
            }
        }
    }
}
