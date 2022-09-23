using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace PCIapi.Model
{
    /// <summary>
    /// The following code is written by Monisree Sai Raji
    /// Date : 22-09-2022
    /// </summary>
    public class ManageExcKeyActivities : DBconnection
    {
        public ManageExcKeyActivities(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<excKeyActivities> getExcKeyActivitiesDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ExcKeyActivityID,ExcKeyActivityDesc FROM MstExcKeyActivities ";
                dbConnection.Open();
                return dbConnection.Query<excKeyActivities>(sQuery);
            }
        }
        public IEnumerable<excKeyActivities> getExcKeyActivitiesDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ExcKeyActivityID,ExcKeyActivityDesc FROM MstExcKeyActivities WHERE ExcKeyActivityID=@_ExcKeyActivityID ";
                dbConnection.Open();
                return dbConnection.Query<excKeyActivities>(sQuery, new { _ExcKeyActivityID = id });
            }
        }
    }
    public class excKeyActivities
    {
        public int ExcKeyActivityID { get; set; }
        public string ExcKeyActivityDesc { get; set; }
    }
}

