using GKU_App.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading.Tasks;

namespace GKU_App.Models.Repositories
{
    public class ServiceCompanyRepository : IServiceCompanyRepository
    {
        private AppDbContext dbContext;

        public ServiceCompanyRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ServiceCompany> GetServiceCompanies(int ownerId)
        {
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
    }
}
