using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GKU_App.Authorization;
using GKU_App.Models;
using GKU_App.DataBaseContext;

namespace GKU_App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrganizationController : Controller
    {
        private AppDbContext dbContext;

        public OrganizationController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ServiceCompany[] GetAllServiceCompanies()
        {
            ServiceCompany[] organizations = dbContext.ServiceCompanies.ToArray();
            for(int i = 0; i < organizations.Length; i++)
            {
                Service current = dbContext.Services.FirstOrDefault(p => p.ServiceId == organizations[i].ServiceId);
                organizations[i].Service = new Service();
                organizations[i].Service.Name = current.Name;
                organizations[i].Service.ServiceId = current.ServiceId;
            }

            return organizations;
        }
    }
}
