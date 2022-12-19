using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PCIapi.Model
{
    public class ManageProjectDetails : DBconnection
    {
        public ManageProjectDetails(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<projectDetails> getProjectDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT SBUName ,AccountName,ProjectId,ProjectName,ProjectManager,ProjectStartDate,ProjectEndDate,ProjectType FROM MstProjectDetails ";
                dbConnection.Open();
                return dbConnection.Query<projectDetails>(sQuery);
            }
        }
        public IEnumerable<projectDetails> getProjectdetails(string id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT SBUName ,AccountName,ProjectId,ProjectName,ProjectManager,ProjectStartDate,ProjectEndDate,ProjectType FROM MstProjectDetails WHERE ProjectId=@_Projectid ";
                dbConnection.Open();
                return dbConnection.Query<projectDetails>(sQuery, new { _Projectid = id });
            }
        }
        public IEnumerable<projectDetails> getProjectDetails(projectDetails _projectDetails)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT SBUName ,AccountName,ProjectId,ProjectName,ProjectManager,ProjectStartDate,ProjectEndDate,ProjectType FROM MstProjectDetails WHERE SBUName=@_strSBUName AND AccountName=@_strAccountName AND ProjectName=@_strProjectName AND ProjectManager=@_strProjectManager AND ProjectType=@_strProjectType ";
                dbConnection.Open();
                return dbConnection.Query<projectDetails>(sQuery, new { _strSBUName = _projectDetails.SBUName, _strAccountName = _projectDetails.AccountName, _strProjectName = _projectDetails.ProjectName, _strProjectManager = _projectDetails.ProjectManager, _strStartDate = _projectDetails.ProjectStartDate, _strEndDate = _projectDetails.ProjectEndDate, _strProjectType = _projectDetails.ProjectType });


            }
        }
        public int insertProjectDetails(projectDetails _projectDetails)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO MstProjectDetails (SBUName,AccountName,ProjectId,ProjectName,ProjectManager,ProjectStartDate,ProjectEndDate,ProjectType )values(@_strSBUName,@_strAccountName,@_strProjectId,@_strProjectName,@_strProjectManager,@_strProjectStartDate,@_strProjectEndDate,@_strProjectType)";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strSBUName = _projectDetails.SBUName, _strAccountName = _projectDetails.AccountName, _strProjectId= _projectDetails.ProjectId, _strProjectName = _projectDetails.ProjectName,  _strProjectManager = _projectDetails.ProjectManager, _strProjectStartDate = _projectDetails.ProjectStartDate, _strProjectEndDate = _projectDetails.ProjectEndDate, _strProjectType= _projectDetails.ProjectType });
                return affectedRows;

            }

        }
        

            
        
        public string getcheckProjectName(string ProjectName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select 1 from  MstProjectDetails  where ProjectName = @_strProjectName";
                dbConnection.Open();
                var result = dbConnection.Query<string>(sQuery, new { _strProjectName = ProjectName });
                if (result.Count() > 0)
                {
                    return "ProjectName exist";
                }
                else
                {
                    return "ProjectName doesnot exist";
                }



            }
        }
        public string UpdateProjectmanager(string SBUName, string AccountName,string id, string projectName, string projectManager, DateTime ProjectStartDate, DateTime ProjectEndDate, string ProjectType)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update MstProjectDetails set SBUName=@_strSBUName,AccountName=@_strAccountName,ProjectId=@_strProjectId ,ProjectName=@_strProjectName,ProjectManager=@_strProjectManager ,ProjectStartDate=@_strProjectStartDate,ProjectEndDate=@_strProjectEndDate,ProjectType=@_strProjectType where ProjectID =@_strProjectID";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strSBUName = SBUName, _strAccountName = AccountName, _strProjectId= id, _strProjectName = projectName, _strProjectManager = projectManager, _strProjectStartDate = ProjectStartDate, _strProjectEndDate = ProjectEndDate, _strProjectType= ProjectType });
                if (affectedRows == 1)
                {
                    return "Updated Successfully";
                }
                else
                {
                    return " Updated Unsuccessfully ";
                }

            }

        }



    }
    

       public class projectDetails
        {

            public string SBUName { get; set; }
            public string AccountName { get; set; }
            public string ProjectId { get; set; }
            public string ProjectName { get; set; }
            public string ProjectManager { get; set; }
            public DateTime ProjectStartDate { get; set; }
            public DateTime ProjectEndDate { get; set; }
            public string ProjectType { get; set; }



        }
    }



