using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
using System.Collections.Generic;

namespace PCIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageProjectDetailsController : ControllerBase
    {
         
        private IConfiguration _configuration;
        private readonly ManageProjectDetails manageProjectDetails;
        public ManageProjectDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageProjectDetails = new ManageProjectDetails(_configuration);
        }
        [HttpGet]
        public IEnumerable<projectDetails> Get()
        {
            return manageProjectDetails.getProjectDetails();
        }

      
        [HttpGet]
        [Route("CheckProjectName")]
        public string CheckProjectName(string CheckProjectName)
        {



            return manageProjectDetails.getcheckProjectName(CheckProjectName);



        }
       


        [HttpGet("{id}")]
        public IEnumerable<projectDetails> get(string id)
        {
            return manageProjectDetails.getProjectdetails(id);
        }

        [HttpPost]
        [Route("insert")]
        public int Insert([FromBody] projectDetails _projectDetails)
        {
            if (ModelState.IsValid)
            {
                if (_projectDetails == null)
                {

                    return 0;
                }
                else
                {
                    var affectedRows = manageProjectDetails.insertProjectDetails(_projectDetails);
                    return affectedRows;
                }
            }
            else
                return 0;
        }

        [HttpPut]
        [Route("updatemanagedetails")]
        public string put([FromBody] projectDetails projectDetails)
        {
            return manageProjectDetails.UpdateProjectmanager(projectDetails.SBUName, projectDetails.AccountName,projectDetails.ProjectId, projectDetails.ProjectName, projectDetails.ProjectManager, projectDetails.ProjectStartDate, projectDetails.ProjectEndDate, projectDetails.ProjectType);


        }
    }
}
   

