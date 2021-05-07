using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class DataForCreatingOwner
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Patronymic { get; private set; }

        public DataForCreatingOwner(string firstName, string lastName, string patronymic)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }
    }
}
