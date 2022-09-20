using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using static PCIapi.Model.ManageMstCompliance;

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
        ManageMstCompliance oManageMstCompliance = new ManageMstCompliance();

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

