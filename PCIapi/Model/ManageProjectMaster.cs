﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
                string sQuery = @"SELECT ProjectID ,ProjectCode,ProjectName,ProjectManager,StartDate,EndDate FROM MstProjectMaster ";
                dbConnection.Open();
                return dbConnection.Query<projectMaster>(sQuery);
            }
        }
        public IEnumerable<projectMaster> getProjectDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ProjectID ,ProjectCode,ProjectName,ProjectManager,StartDate,EndDate FROM MstProjectMaster WHERE ProjectID=@_Projectid ";
                dbConnection.Open();
                return dbConnection.Query<projectMaster>(sQuery, new { _Projectid = id });
            }
        }
        public IEnumerable<projectMaster> getProjectDetails(projectMaster _projectMaster)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ProjectID ,ProjectCode,ProjectName,ProjectManager,StartDate,EndDate  FROM MstProjectMaster WHERE ProjectCode=@_strProjectCode AND ProjectName=@_strProjectName AND ProjectManager=@_strProjectManager ";
                dbConnection.Open();
                return dbConnection.Query<projectMaster>(sQuery, new { _strProjectCode = _projectMaster.ProjectCode, _strProjectName = _projectMaster.ProjectName, _strProjectManager = _projectMaster.ProjectManager, _strStartDate = _projectMaster.StartDate, _strEndDate = _projectMaster.EndDate });
            }
        }
        public int insertProjectDetails(projectMasterDto _projectMaster)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO MstProjectMaster (ProjectCode,ProjectName,ProjectManager,StartDate,EndDate )  values(@_strProjectCode,@_strProjectName,@_strProjectManager,@_strStartDate,@_strEndDate)";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strProjectCode = _projectMaster.ProjectCode, _strProjectName = _projectMaster.ProjectName, _strProjectManager = _projectMaster.ProjectManager, _strStartDate = _projectMaster.StartDate, _strEndDate = _projectMaster.EndDate });
                return affectedRows;

            }

        }
        public IEnumerable<Projectcount> getProjectCount()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"  SELECT  COUNT(ProjectManager) FROM MstProjectMaster   ";
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
        public string getcheckingProjectNmae(string ProjectName)
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
        public string updateProjectmanager(int id, string projectName, string projectManager)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"update MstProjectMaster set ProjectName=@_strProjectName,ProjectManager=@_strProjectManager where ProjectID =@_strProjectID";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strProjectName = projectName, _strProjectManager = projectManager, _strProjectID = id });
                if (affectedRows ==1)
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
    }
    public class projectMaster
    {
        public int ProjectID { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class projectMasterUpadteDto
    {



        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
    }
    public class Projectcount
    {
        public string ProjectManager { get; set; }

    }

}
