using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Exceptions
{
    public class CSVLoadException : Exception
    {
        public CSVLoadException(string message) : base(message) { }
    }
}
