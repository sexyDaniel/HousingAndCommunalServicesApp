using GKU_App.DataBaseContext;
using GKU_App.Models;
using GKU_App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Services
{
    public class CalcService : ICalculationService
    {
        delegate bool Operation(Charge c);
        private AppDbContext context;
        public CalcService(AppDbContext context) => this.context = context;
        public double MonthSumCalculation(DateTime month,int personalNumber)
        {

            return Calculation((c)=>c.ChargeDate.Year==month.Year&&c.ChargeDate.Month==month.Month, personalNumber);
        }

        public double PeriodSumCalculation(DateTime start, DateTime finish, int personalNumber)
        {
            return Calculation((c) => c.ChargeDate >= start && c.ChargeDate <= finish, personalNumber); ;
        }

        public double YearSumCalculation(DateTime year, int personalNumber)
        {
            return Calculation((c) => c.ChargeDate.Year == year.Year, personalNumber);
        }

        private double Calculation(Operation expression,int personalNumber) 
        {
            Console.WriteLine(expression(new Charge { ChargeDate = new DateTime(2021, 5, 3) }));
            return context.Charges
                .Join(context.Properties, c => c.PropertyId, p => p.PropertyId, (c, p) => new { c, p })
                .Join(context.Buildings, lastJoin => lastJoin.p.BuildingId, b => b.BuildingId, (lastJoin, b) => new { lastJoin, b })
                .Join(context.Tariffs, lastJoin => lastJoin.b.BuildingId, t => t.BuildingId, (lastJoin, t) => new { lastJoin, t })
                .Join(context.Services, lastJoin => lastJoin.lastJoin.lastJoin.c.ServiceId, s => s.ServiceId, (lastJoin, s) => new { lastJoin, s }).ToList()
                .Where(res => res.lastJoin.lastJoin.lastJoin.p.OwnerId == personalNumber && res.s.ServiceId == res.lastJoin.t.ServiceId&& expression(res.lastJoin.lastJoin.lastJoin.c))
                .Sum(res => res.lastJoin.t.Value * res.lastJoin.lastJoin.lastJoin.c.Volume);
        }
    }
}
