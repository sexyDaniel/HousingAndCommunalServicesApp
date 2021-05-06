using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models.Repositories.Interfaces
{
    public interface ITariffRepository
    {
        List<Tariff> GetTariffs(int personalId);
    }
}
