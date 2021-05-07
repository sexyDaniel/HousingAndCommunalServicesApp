using GKU_App.Models.Requests;
using GKU_App.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GKU_App.Services.Interfaces
{
    public interface IAdminService
    {
        AdminAuthResponse Auth(AdminAuthRequest request);
    }
}
