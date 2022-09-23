using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using static PCIapi.Model.ManageMstCompliance;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Controllers
{

    /// <summary>
    /// following code has written by velpula Pushpa
    /// date 20/09/2022
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManageCeremonyController : Controller
    {
        private IConfiguration _configuration;
        private ManageCeremony oManageCeremonye;
        public ManageCeremonyController(IConfiguration configuration)
        {
            _configuration = configuration;
             oManageCeremonye = new ManageCeremony(_configuration);
        }

        [HttpGet]
        public IEnumerable<mstCeremony> get()
        {
            return oManageCeremonye.getMstComplianceDetails();
        }
        [HttpGet("{id}")]
        public IEnumerable<mstCeremony> get(int id)
        {
            return oManageCeremonye.getMstComplianceDetails();
        }

    }


}



