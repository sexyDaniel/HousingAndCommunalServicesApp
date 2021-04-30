using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GKU_App.Authorization
{
    public class CokkieSaver : IDataSaver
    {
        private HttpContext context;

        public CokkieSaver(HttpContext context)
        {
            this.context = context;
        }

        public void Save(string key, string value)
        {
            context.Response.Cookies.Append(key, value);
        }

        public void Delete(string key)
        {
            context.Response.Cookies.Delete(key);
        }

        public bool TryGetValue(string key, out string value)
        {
            if(context.Request.Cookies.TryGetValue(key, out value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
