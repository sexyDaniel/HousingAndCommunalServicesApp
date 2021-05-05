using GKU_App.Models;
using GKU_App.Models.Repositories.Interfaces;
using GKU_App.Models.Requests;
using GKU_App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private ICalculationService calculationService;
        private ITariffRepository tariffRepository;
        public CalculationController(ICalculationService calculationService, ITariffRepository tariffRepository) 
        {
            this.calculationService = calculationService;
            this.tariffRepository = tariffRepository;
        }

        [HttpPost]
        public double MonthSumCalculation(MonthCalcRequest calcRequest) 
        {
            return calculationService.MonthSumCalculation(calcRequest.Date, calcRequest.PersonalId);
        }

        [HttpPost]
        public double YearSumCalculation(YearCalcRequest calcRequest)
        {
            return calculationService.YearSumCalculation(new DateTime(calcRequest.Year,12,31), calcRequest.PersonalId);
        }

        [HttpPost]
        public double PeriodSumCalculation(PeriodCalcRequest calcRequest)
        {
            return calculationService.PeriodSumCalculation(calcRequest.Start, calcRequest.Finish, calcRequest.PersonalId);
        }

        [HttpGet]
        public List<Tariff> GetTariff()
        {
            var id = HttpContext.Request.Cookies["currentOwner"];
            return tariffRepository.GetTariffs(int.Parse(id)).ToList();
        }
    }
}
