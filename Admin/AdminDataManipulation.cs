using GKU_App.DataBaseContext;
using GKU_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Admin
{
    public class AdminDataManipulation : IDataManipulation
    {
        private AppDbContext dbContext;

        public AdminDataManipulation(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void ChangeOwner(DataForChangingOwner data)
        {
            Owner owner = dbContext.Owners.FirstOrDefault(x => x.PersonalAccount == data.Id);
            owner.FirstName = data.FirstName;
            owner.LastName = data.LastName;
            owner.Patronymic = data.Patronymic;
            dbContext.Update(owner);

            dbContext.SaveChanges();
        }

        public void Create(DataForCreatingOwner data)
        {
            Owner owner = new Owner();
            owner.FirstName = data.FirstName;
            owner.LastName = data.LastName;
            owner.Patronymic = data.Patronymic;
            dbContext.Owners.Add(owner);

            dbContext.SaveChanges();
        }

        public void DeleteOwner(DataForRemoveOwner data)
        {
            Owner owner = dbContext.Owners.FirstOrDefault(p => p.PersonalAccount == data.Id);
            if (owner != null)
            {
                dbContext.Owners.Remove(owner);
                dbContext.SaveChanges();
            }
        }
    }
}
