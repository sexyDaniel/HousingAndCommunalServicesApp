using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Models
{
    public class DataForChangingOwner : DataForCreatingOwner
    {
        public int Id { get; private set; }

        public DataForChangingOwner(string firstName, string lastName, string patronymic, int id) 
            : base(firstName, lastName, patronymic)
        {
            Id = id;
        }
    }
}
