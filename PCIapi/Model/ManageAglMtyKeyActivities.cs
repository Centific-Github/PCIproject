using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Model
{
    /// <summary>
    /// Following code has been written by :Jyothi
    /// Date:20-09-2022
    /// </summary>
    public class ManageAglMtyKeyActivities :DBconnection
    {
        public ManageAglMtyKeyActivities(IConfiguration configuration) :base(configuration)
        {

        }
        public IEnumerable<AglMtyKeyActivities> getAglMtyKeyActivitiesDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT KeyActivitiesID,KeyActivitiesDesc FROM MstAglMtyKeyActivities";
                dbConnection.Open();
                return dbConnection.Query<AglMtyKeyActivities>(sQuery);
            }
        }
        public IEnumerable<AglMtyKeyActivities> getAglMtyKeyActivitiesDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  KeyActivitiesID,KeyActivitiesDesc FROM MstAglMtyKeyActivities   WHERE KeyActivitiesID  =@_KeyActivitiesID";
                dbConnection.Open();
                return dbConnection.Query<AglMtyKeyActivities>(sQuery, new { _KeyActivitiesID = id });
            }
        }

    }
    public class AglMtyKeyActivities
    {
        public int KeyActivitiesID { get; set; }
        public string KeyActivitiesDesc { get; set; }
    }
} 
