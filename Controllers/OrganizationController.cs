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
            return dbContext.ServiceCompanies.ToArray();
        }
    }
}
