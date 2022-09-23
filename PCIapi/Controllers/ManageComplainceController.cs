using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using static PCIapi.Model.ManageMstCompliance;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Controllers
{
    /// <summary>
    /// following code has written by velpula Pushpa
    /// date 20/09/2022
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManageComplianceController : Controller
    {

        private IConfiguration _configuration;
        private ManageMstCompliance oManageMstCompliance;
        public ManageComplianceController(IConfiguration configuration)
        {
            _configuration = configuration;
             oManageMstCompliance = new ManageMstCompliance(_configuration);
        }

        [HttpGet]
        public IEnumerable<mstCompliance> get()
        {
            return oManageMstCompliance.getMstComplianceDetails();
        }
        [HttpGet("{id}")]
        public IEnumerable<mstCompliance> get(int id)
        {
            return oManageMstCompliance.getMstComplianceDetails();
        }
        
    }  


}

