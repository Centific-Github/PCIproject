using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;

namespace PCIapi.Controllers
{
    /// <summary>
    /// This code is written by D.Hemasri
    /// Date-20-09-2022
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManageProjectMasterController : Controller
    {
        ManageProjectMaster oManageProjectMaster = new ManageProjectMaster();

        [HttpGet]
        public IEnumerable<projectMaster> get()
        {
            return oManageProjectMaster.getProjectDetails();
        }
        [HttpGet("{id}")]
        public IEnumerable<projectMaster> get(int id)
        {
            return oManageProjectMaster.getProjectDetails(id);
        }



    }
}