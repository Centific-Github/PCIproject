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
        private readonly ManageProjectMaster manageProjectMaster;


        public ManageProjectMasterController()
        {
            manageProjectMaster = new ManageProjectMaster();
        }
        [HttpGet]
        public IEnumerable<projectMaster> get()
        {
            return manageProjectMaster.getProjectDetails();
        }
        [HttpGet("{id}")]
        public IEnumerable<projectMaster> get(int id)
        {
            return manageProjectMaster.getProjectDetails(id);
        }



    }
}
