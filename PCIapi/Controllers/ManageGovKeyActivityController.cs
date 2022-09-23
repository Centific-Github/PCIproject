
using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using static PCIapi.Model.ManageGovKeyActivity;
using Microsoft.Extensions.Configuration;


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
        private IConfiguration _configuration;
        private ManageGovKeyActivity oManageGovKeyActivity;
        public ManageGovKeyActivityController(IConfiguration configuration)
        {
            _configuration=configuration;
            oManageGovKeyActivity = new ManageGovKeyActivity(_configuration);

        }

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

