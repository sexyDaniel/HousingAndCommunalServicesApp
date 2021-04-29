using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GKU_App.Authorization;
using GKU_App.Models;

namespace GKU_App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthorizationController : Controller
    {
        private IOwnerAuthorization ownerAuthorization;

        public AuthorizationController(IOwnerAuthorization ownerAuthorization)
        {
            this.ownerAuthorization = ownerAuthorization;
        }

        [HttpPost]
        public AuthorizationAnswer GetOwner(AuthorizationRequestData data)
        {
            AuthorizationAnswer answer;
            
            if(ownerAuthorization.HaveOwner(data.Id))
            {
                Owner owner = ownerAuthorization.GetOwner(data.Id);
                answer = new AuthorizationAnswer(true, owner);
            }
            else
            {
                answer = new AuthorizationAnswer(false, null);
            }

            return answer;
        }
    }
}
