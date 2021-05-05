using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GKU_App.Authorization;
using GKU_App.Models;
using GKU_App.Models.Responses;
using GKU_App.Models.Requests;

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
                answer = new AuthorizationAnswer(owner);
                HttpContext.Response.Cookies.Append("currentOwner", owner.PersonalAccount.ToString());
            }
            else
            {
                answer = new AuthorizationAnswer(null);
            }

            return answer;
        }

        [HttpPost]
        public AdminAuthResponse AdminAuthorization(AdminAuthRequest request)
        {


            return null;
        }
    }
}
