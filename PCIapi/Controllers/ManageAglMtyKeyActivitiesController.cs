using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Controllers
{
    /// <summary>
    /// Following code has been written by :Jyothi
    /// Date:20-09-2022
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAglMtyKeyActivitiesController : Controller
    {

        private readonly ManageAglMtyKeyActivities manageAglMtyKeyActivities;


        private IConfiguration _configuration;
        public ManageAglMtyKeyActivitiesController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageAglMtyKeyActivities = new ManageAglMtyKeyActivities(_configuration);
        }

        [HttpGet]
        public IEnumerable<AglMtyKeyActivities> get()
        {
            return manageAglMtyKeyActivities.getAglMtyKeyActivitiesDetails();
        }
        [HttpGet("{id}")]
        public IEnumerable<AglMtyKeyActivities> get(int id)
        {
            return manageAglMtyKeyActivities.getAglMtyKeyActivitiesDetails(id);
        }
    }
}
