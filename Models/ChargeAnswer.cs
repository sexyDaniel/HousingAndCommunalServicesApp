using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class ChargeAnswer
    {
        public Charge Charge { get; private set;}
        public Tariff Tariff { get; private set; }

        public ChargeAnswer(Charge charge, Tariff tariff)
        {
            Charge = charge;
            Tariff = tariff;
        }
    }
}
