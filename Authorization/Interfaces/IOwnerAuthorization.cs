using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GKU_App.Models;

namespace GKU_App.Authorization
{
    public interface IOwnerAuthorization
    {
        public bool HaveOwner(int id);

        public Owner GetOwner(int id);
    }
}
