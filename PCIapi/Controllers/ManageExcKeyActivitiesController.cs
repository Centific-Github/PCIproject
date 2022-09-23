using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Controllers
{
    /// <summary>
    /// The following code is written by Monisree Sai Raji
    /// Date : 22-09-2022
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class ManageExcKeyActivitiesController : Controller
    {
        private IConfiguration _configuration;
        private ManageExcKeyActivities oManageExcKeyActivities;

        public ManageExcKeyActivitiesController(IConfiguration configuration)
        {
            _configuration = configuration;
            oManageExcKeyActivities = new ManageExcKeyActivities(_configuration);
        }
         

        [HttpGet]
        public IEnumerable<excKeyActivities> get()
        { 
            return oManageExcKeyActivities.getExcKeyActivitiesDetails();
        }
        [HttpGet("{id}")]
        public IEnumerable<excKeyActivities> get(int id)
        {
            return oManageExcKeyActivities.getExcKeyActivitiesDetails(id);
        }
    }
}
