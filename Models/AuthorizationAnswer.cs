using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class AuthorizationAnswer
    {
        public bool Answer { get; private set; }
        
        public Owner Owner { get; private set; }

        public AuthorizationAnswer(bool answer, Owner owner)
        {
            Answer = answer;
            Owner = owner;
        }
    }
}
