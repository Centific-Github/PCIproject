using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using static PCIapi.Model.ManageProjectMaster;

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

        [HttpPost]
        [Route("insert")]
        public int Insert([FromBody] projectMaster _projectMaster)
        {
            if (ModelState.IsValid)
            {
                if (_projectMaster == null)
                {
                   
                    return 0;
                }



                else
                {



                    var affectedRows = manageProjectMaster.insertProjectDetails(_projectMaster);
                    return affectedRows;
                }
            }
            else
                return 0;
        }




    }
}