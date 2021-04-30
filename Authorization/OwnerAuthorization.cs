using GKU_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GKU_App.DataBaseContext;

namespace GKU_App.Authorization
{
    public class OwnerAuthorization : IOwnerAuthorization
    {
        private AppDbContext dbContext;

        public OwnerAuthorization(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Owner GetOwner(int id)
        {
            return dbContext.Owners.FirstOrDefault(p => p.PersonalAccount == id);
        }

        public bool HaveOwner(int id)
        {
            return dbContext.Owners.Any(x => x.PersonalAccount == id);
        }
    }
}
