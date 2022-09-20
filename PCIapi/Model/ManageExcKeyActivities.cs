
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace PCIapi.Model
{
    public class ManageExcKeyActivities : DBconnection
    {
        public IEnumerable<ExcKeyActivities> getExcKeyActivitiesDeatails() 
        { 
            using (IDbConnection dbConnection = Connection)
            { 
                string sQuery = @"SELECT  ExcKeyActivityID, ExcKeyActivityDesc FROM MstExcKeyActivities"; 
                dbConnection.Open(); return dbConnection.Query<ExcKeyActivities>(sQuery); 
            } 
        }

        
        public IEnumerable<ExcKeyActivities> getExcKeyActivitiesDeatails(int id) 
        { 
            using (IDbConnection dbConnection = Connection) 
           
            { 
                string sQuery = @"SELECT ExcKeyActivityID,ExcKeyActivityDesc FROM ExcKeyActivityID WHERE ExcKeyActivityID=@_ExcKeyActivityID";
                dbConnection.Open();
                return dbConnection.Query<ExcKeyActivities>(sQuery, new { _ExcKeyActivityID = id });
            } 
        }

    }

    public class excKeyActivities 
    { 
        public int ExcKeyActivityID { get; set; } 
        public string ExcKeyActivityDesc { get; set; } }
}


