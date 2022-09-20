using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;

namespace PCIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageExcKeyActivitiesController : Controller
    {
        ManageExcKeyActivities oExcKeyActivitiess = new ManageExcKeyActivities();
        
        [HttpGet]
        public IEnumerable<excKeyActivities> get()
        {
            return (IEnumerable<excKeyActivities>)oExcKeyActivitiess.getExcKeyActivitiesDeatails();
        }
        [HttpGet("{id}")]
        public IEnumerable<excKeyActivities> get(int id)
        {
            return (IEnumerable<excKeyActivities>)oExcKeyActivitiess.getExcKeyActivitiesDeatails(id);
        }
    }
}

