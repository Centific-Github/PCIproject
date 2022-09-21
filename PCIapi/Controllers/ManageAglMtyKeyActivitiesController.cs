using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;

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


            public ManageAglMtyKeyActivitiesController()
            {
            manageAglMtyKeyActivities = new ManageAglMtyKeyActivities();
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
