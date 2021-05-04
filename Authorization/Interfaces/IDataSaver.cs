using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Authorization
{
    public interface IDataSaver
    {
        public void Save(string key, string value);

        public void Delete(string key);

        public bool TryGetValue(string key, out string value);
    }
}
