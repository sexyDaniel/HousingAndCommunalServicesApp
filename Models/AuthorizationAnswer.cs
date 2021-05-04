using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class AuthorizationAnswer
    {
        public Owner Owner { get; private set; }

        public AuthorizationAnswer(Owner owner)
        {
            Owner = owner;
        }
    }
}
