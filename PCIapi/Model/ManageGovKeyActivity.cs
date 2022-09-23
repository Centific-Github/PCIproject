
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Model
{
    /// <summary>
    /// following code was written by Sravanthi
    /// date: 20-09-2022
    /// </summary>
    public class ManageGovKeyActivity : DBconnection
    {
        public ManageGovKeyActivity(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<GovKeyActivity> getGovKeyActivityDetails()
        {
            using (IDbConnection dbConnection = Connection) 
            {
                string sQuery = @"SELECT  ActivityID, ActivityDesc FROM MstGovKeyActivity ";
                dbConnection.Open();
                return dbConnection.Query<GovKeyActivity>(sQuery); 
            }

        }
        public IEnumerable<GovKeyActivity> getGovKeyActivityDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  ActivityID, ActivityDesc FROM MstGovKeyActivity WHERE  ActivityID=@_ActivityID ";
                dbConnection.Open();
                return dbConnection.Query<GovKeyActivity>(sQuery, new { _ActivityID = id }); ; }

        }

        public class GovKeyActivity 
        {
            public int ActivityID { get; set; } 
            public string ActivityDesc { get; set; } 
        }
    }
}

