using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;

namespace PCIapi.Model
{
    public class ManageProjectMaster : DBconnection
    {
        public ManageProjectMaster(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<projectMaster> getProjectDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ProjectID ,ProjectCode,ProjectName,ProjectManager,StartDate,EndDate,SBUName,AccountName FROM MstProjectMaster ";
                dbConnection.Open();
                return dbConnection.Query<projectMaster>(sQuery);
            }
        }
        public IEnumerable<projectMaster> getProjectDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ProjectID ,ProjectCode,ProjectName,ProjectManager,StartDate,EndDate,SBUName,AccountName FROM MstProjectMaster WHERE ProjectID=@_Projectid ";
                dbConnection.Open();
                return dbConnection.Query<projectMaster>(sQuery, new { _Projectid = id });
            }
        }
        public IEnumerable<projectMaster> getProjectDetails(projectMaster _projectMaster)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ProjectID ,ProjectCode,ProjectName,ProjectManager,StartDate,EndDate ,SBUName,AccountName FROM MstProjectMaster WHERE ProjectCode=@_strProjectCode AND ProjectName=@_strProjectName AND ProjectManager=@_strProjectManager ";
                dbConnection.Open();
                return dbConnection.Query<projectMaster>(sQuery, new { _strProjectCode = _projectMaster.ProjectCode, _strProjectName = _projectMaster.ProjectName, _strProjectManager = _projectMaster.ProjectManager, _strStartDate = _projectMaster.StartDate, _strEndDate = _projectMaster.EndDate });
               

            }
        }
        public int insertProjectDetails(projectMasterDto _projectMaster)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO MstProjectMaster (ProjectCode,ProjectName,ProjectManager,StartDate,EndDate,SBUName,AccountName )values(@_strProjectCode,@_strProjectName,@_strProjectManager,@_strStartDate,@_strEndDate,@_strSBUName,@_strAccountName)"; 
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strProjectCode = _projectMaster.ProjectCode, _strProjectName = _projectMaster.ProjectName, _strProjectManager = _projectMaster.ProjectManager, _strStartDate = _projectMaster.StartDate, _strEndDate = _projectMaster.EndDate,  _strSBUName = _projectMaster.SBUName, _strAccountName = _projectMaster.AccountName });
                return affectedRows;

            }

        }
        public IEnumerable<Projectcount> ProjectCount( )
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select count(ProjectID) as ProjectIDCount From MstProjectMaster";
                dbConnection.Open();
                return dbConnection.Query<Projectcount>(sQuery);
            }
        }

        

        public string getcheckingProjectCode(string ProjectCode)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select 1 from  MstProjectMaster  where ProjectCode = @_strProjectCode";
                dbConnection.Open();
                var result = dbConnection.Query<string>(sQuery, new { _strProjectCode = ProjectCode });
                if (result.Count() > 0)
                {
                    return "ProjectCode exist";
                }
                else
                {
                    return "ProjectCode doesnot exist";
                }



            }
        }
        public string getcheckingProjectNmae(string  ProjectName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select 1 from  MstProjectMaster  where ProjectName = @_strProjectName";
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
        public string updateProjectmanager(int id, string projectName, string projectManager, DateTime startDate, DateTime endDate,string ? SBUName, string ? AccountName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update MstProjectMaster set ProjectName=@_strProjectName,ProjectManager=@_strProjectManager ,StartDate=@_strStartDate,EndDate=@_strEndDate,SBUName=@_strSBUName,AccountName=@_strAccountName where ProjectID =@_strProjectID";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strProjectName = projectName, _strProjectManager = projectManager, _strProjectID = id, _strStartDate = startDate, _strEndDate = endDate, _strSBUName = SBUName, _strAccountName = AccountName });
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
    public class projectMasterDto
    {

        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string[] ? SBUName { get; set; }
        public string ? AccountName { get; set; }
    }
    public class projectMaster
    {
        public int ProjectID { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ? SBUName { get; set; }
        public string ? AccountName { get; set; }


    }
    public class projectMasterUpadteDto
    {



        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ? SBUName { get; set; }
        public string ? AccountName { get; set; }

    }
    public class Projectcount
    {
        public int ProjectIDCount { get; set; }

    }

}
