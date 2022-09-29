using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
using System.Collections.Generic;

namespace PCIapi.Controllers
{
    /// <summary>
    /// Following code was written by: Sumalatha
    /// Date:20-Sept-2022
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManageSubActivityMasterController : Controller
    {
        private IConfiguration _configuration;
        private readonly ManageSubActivityMaster manageSubActivityMaster;
        public ManageSubActivityMasterController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageSubActivityMaster = new ManageSubActivityMaster(_configuration);
        }
        [HttpGet]
        public IEnumerable<subActivityMaster> get()
        {
            return manageSubActivityMaster.getsubActivityDetails();
        }

        [HttpGet("{aears id,heading id}")]
        public IEnumerable<subActivityMaster> get(int aearsid,int headingid)
        {
            return manageSubActivityMaster.getsubActivityDetails(aearsid,headingid);
        }
    }
}
