using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models.Repositories
{
    public interface IServiceCompanyRepository
    {
        public List<ServiceCompany> GetServiceCompanies(int ownerId);
    }
}
