using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace PCIapi.Model

{
    public class ManageProjectMaster : DBconnection
    {

        public IEnumerable<projectMaster> getProjectDetails(string manager)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ProjectID ,ProjectCode,ProjectManager FROM MstProjectMaster ";
                dbConnection.Open();
                return dbConnection.Query<projectMaster>(sQuery);
            }
        }

        internal IEnumerable<projectMaster> getProjectDetails()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<projectMaster> getProjectDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ProjectID ,ProjectCode,ProjectManager FROM MstProjectMaster WHERE ProjectID=@_Projectid ";
                dbConnection.Open();
                return dbConnection.Query<projectMaster>(sQuery, new { _Projectid = id });
            }
        }
        public IEnumerable<projectMaster> getProjectDetails(projectMaster _projectMaster)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ProjectID ,ProjectCode,ProjectManager FROM MstProjectMaster WHERE ProjectCode=@_strProjectCode AND ProjectManager=@_strProjectManager ";
                dbConnection.Open();
                return dbConnection.Query<projectMaster>(sQuery, new { _strProjectCode = _projectMaster.ProjectCode, _strProjectManager = _projectMaster.ProjectManager });
            }
        }
        public int insertProjectDetails(projectMaster _projectMaster)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO MstProjectMaster (ProjectCode,ProjectManager )  values(@_strProjectCode,@_strProjectManager)";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new {_strProjectCode = _projectMaster.ProjectCode, _strProjectManager = _projectMaster.ProjectManager });
                return affectedRows;



            }






        }






        public class projectMaster

        {

            public int ProjectID { get; set; }
            public string ProjectCode { get; set; }
            public string ProjectManager { get; set; }
        }
    }
}

