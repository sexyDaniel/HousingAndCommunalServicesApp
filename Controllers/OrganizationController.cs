using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using GKU_App.Models;
using GKU_App.Models.Repositories;
using System.Linq;
using System.Threading.Tasks;
using GKU_App.Authorization;
using GKU_App.DataBaseContext;


namespace GKU_App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrganizationController : Controller
    {
        private IServiceCompanyRepository serviceCompany;

        public OrganizationController(IServiceCompanyRepository serviceCompany)
        { 
            this.serviceCompany = serviceCompany;
        }

        [HttpGet]
        public List<ServiceCompany> GetAllServiceCompanies()
        {
            int ownerId= 0;
            if (HttpContext.Request.Cookies.TryGetValue("currentOwner", out string value))
            {
                int.TryParse(value, out ownerId);

                return serviceCompany.GetServiceCompanies(ownerId);
            }
            else
            {
                return null;
            }
        }
    }
}
