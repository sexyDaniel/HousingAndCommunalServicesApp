using Microsoft.AspNetCore.Mvc;
using GKU_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GKU_App.Admin;

namespace GKU_App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdminOperationsController : Controller
    {
        private IDataManipulation dataManipulation;

        public AdminOperationsController(IDataManipulation dataManipulation)
        {
            this.dataManipulation = dataManipulation;
        }

        [HttpPost]
        public void CreateOwner(DataForCreatingOwner data)
        {
            dataManipulation.Create(data);
        }

        [HttpPost]
        public void ChangeOwner(DataForChangingOwner data)
        {
            dataManipulation.ChangeOwner(data);
        }

        [HttpPost]
        public void DeleteOwner(DataForRemoveOwner data)
        {
            dataManipulation.DeleteOwner(data);
        }
    }
}
