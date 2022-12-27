using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
using System;
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
        public IEnumerable<projectDetails> get(int id)
        {
            return manageProjectDetails.getProjectdetails(id);
        }
        [HttpGet]
        [Route("detailsbydate")]
        public IEnumerable<ProjectDetailsByDate> getProjectdetailsbydate(DateTime ProjectStartDate, DateTime ProjectEndDate)
        {
            return manageProjectDetails.getProjectdetailsbydate(ProjectStartDate, ProjectEndDate);
        }

        [HttpPost]
        [Route("insert")]
        public int Insert([FromBody] projectDetailsDTO _projectDetailsDTO)
        {
            if (ModelState.IsValid)
            {
                if (_projectDetailsDTO == null)
                {

                    return 0;
                }
                else
                {
                    var affectedRows = manageProjectDetails.insertProjectDetails(_projectDetailsDTO);
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
            return manageProjectDetails.UpdateProjectmanager(projectDetails.ProjectDetailsID, projectDetails.SBUName, projectDetails.AccountName,projectDetails.ProjectCode, projectDetails.ProjectName, projectDetails.ProjectManager, projectDetails.ProjectStartDate, projectDetails.ProjectEndDate, projectDetails.ProjectType);


        }
        [HttpGet]
        [Route("GetProjectDetails")]
        public IEnumerable<SpProjectDetails> GetProjectDetails()
        {
            return manageProjectDetails.GetProjectDetails();
        }
        [HttpGet]
        [Route("DashBoard")]
        public DashBoard DashBoard(string SUBName,string AccountName,string ProjectName,string AuditSatus,string StartDate,string EndDate)
        {
            return manageProjectDetails.GetDashBoard(SUBName,AccountName,ProjectName,AuditSatus,StartDate,EndDate);
        }

    }
}
   

