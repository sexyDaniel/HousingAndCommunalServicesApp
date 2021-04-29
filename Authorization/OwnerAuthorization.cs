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
            var owner = dbContext.Owners.FirstOrDefault(p => p.PersonalAccount == id);
            return owner;
        }

        public bool HaveOwner(int id)
        {
            var owner = dbContext.Owners.FirstOrDefault(p => p.PersonalAccount == id);

            if(owner != null)
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
