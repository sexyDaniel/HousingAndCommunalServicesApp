using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GKU_App.Models;

namespace GKU_App.AdminRepositories
{
    public interface IDataManipulation
    {
        public void ChangeOwner(DataForChangingOwner data);

        public void Create(DataForCreatingOwner data);

        public void DeleteOwner(DataForRemoveOwner id);
    }
}
