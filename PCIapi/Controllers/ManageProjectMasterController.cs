using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
using System.Collections.Generic;

namespace PCIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageProjectMasterController : Controller
    {
        private IConfiguration _configuration;
        private readonly ManageProjectMaster manageProjectMaster;
        public ManageProjectMasterController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageProjectMaster = new ManageProjectMaster(_configuration);
        }
        [HttpGet]
        public IEnumerable<projectMaster> get()
        {
            return manageProjectMaster.getProjectDetails();
        }

        [HttpGet("{id}")]
        public IEnumerable<projectMaster> get(int id)
        {
            return manageProjectMaster.getProjectDetails();
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
  
    

