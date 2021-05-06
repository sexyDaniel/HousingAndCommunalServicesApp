using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Exceptions
{
    public class CookieEmptyException : Exception
    {
        public CookieEmptyException(string message) : base(message) { }
    }
}
