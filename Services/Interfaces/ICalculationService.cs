using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Services.Interfaces
{
    public interface ICalculationService
    {
        double MonthSumCalculation(DateTime month, int personalNumber);
        double YearSumCalculation(DateTime year, int personalNumber);
        double PeriodSumCalculation(DateTime start, DateTime finish, int personalNumber);
    }
}
