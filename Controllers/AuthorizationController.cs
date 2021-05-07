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
using GKU_App.Services.Interfaces;

namespace GKU_App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthorizationController : Controller
    {
        private IOwnerAuthorization ownerAuthorization;
        private IAdminService adminService;
        public AuthorizationController(IOwnerAuthorization ownerAuthorization,IAdminService adminService)
        {
            this.ownerAuthorization = ownerAuthorization;
            this.adminService = adminService;
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
            var response = adminService.Auth(request);
            if (response.IsSuccessfull) 
            {
                HttpContext.Response.Cookies.Append("Login", response.Login);
                HttpContext.Response.Cookies.Append("Key", response.Key);
            }
            return adminService.Auth(request);
        }

        [HttpPost]
        public void Exit()
        {
            HttpContext.Response.Cookies.Delete("currentOwner");
        }
    }
}
