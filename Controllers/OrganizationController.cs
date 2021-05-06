using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GKU_App.Authorization;
using GKU_App.Models;
using GKU_App.DataBaseContext;
using Microsoft.EntityFrameworkCore.Internal;

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
        public List<ServiceCompany> GetAllServiceCompanies()
        {
            int ownerId= 0;
            if (HttpContext.Request.Cookies.TryGetValue("currentOwner", out string value))
            {
                int.TryParse(value, out ownerId);

                var buildings = dbContext.Properties
                .Join(dbContext.Owners, p => p.OwnerId, c => c.PersonalAccount, (p, c) => new { p, c })
                .Join(dbContext.Buildings, last => last.p.BuildingId, b => b.BuildingId, (last, b) => new { last, b })
                .Where(result => result.last.c.PersonalAccount == ownerId)
                .Select(result => result.b);

                List<ServiceCompany> companies = new List<ServiceCompany>();

                foreach (var building in buildings.Include(p => p.ServiceCompanies))
                {
                    foreach (var company in building.ServiceCompanies)
                    {
                        companies.Add(company);
                    }
                }

                companies.Distinct();

                for (int i = 0; i < companies.Count; i++)
                {
                    companies[i].Service = dbContext.Services.FirstOrDefault(p => p.ServiceId == companies[i].ServiceId);
                }

                return companies;
            }
            else
            {
                return null;
            }
            
        }
    }
}
