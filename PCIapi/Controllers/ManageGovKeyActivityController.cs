
using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using static PCIapi.Model.ManageGovKeyActivity;

namespace PCIapi.Controllers
{
    /// <summary>
    /// following code was written by Sravanthi
    /// date: 20-09-2022
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]
    public class ManageGovKeyActivityController : Controller
    {
        ManageGovKeyActivity oManageGovKeyActivity = new ManageGovKeyActivity();
        [HttpGet] public IEnumerable<GovKeyActivity> get() 
        {
            return oManageGovKeyActivity.getGovKeyActivityDetails();
        }
        [HttpGet("{id}")] 
        public IEnumerable<GovKeyActivity> get(int id) 
        {
            return oManageGovKeyActivity.getGovKeyActivityDetails(id);
        }

    }
}

