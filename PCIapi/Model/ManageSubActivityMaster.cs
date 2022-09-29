using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace PCIapi.Model
{
    /// <summary>
    /// Following code was written by: Sumalatha
    /// Date:20-Sept-2022
    /// </summary>
    public class ManageSubActivityMaster : DBconnection
    {
        public ManageSubActivityMaster(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<subActivityMaster> getsubActivityDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  SubHeadingID,AreasID,HeadingID,keyDescription  FROM MstSubActivityMaster";
                dbConnection.Open();
                return dbConnection.Query<subActivityMaster>(sQuery);
            }
        }
        public IEnumerable<subActivityMaster> getsubActivityDetails(int areasId, int headingId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT SubHeadingID,AreasID,HeadingID,keyDescription FROM MstSubActivityMaster WHERE AreasID=@_areasId AND HeadingID=@_HeadingID";
                dbConnection.Open();
                return dbConnection.Query<subActivityMaster>(sQuery, new { _areasId= areasId, _HeadingID = headingId });
            }
        }
    }

    public class subActivityMaster
    {
        public int SubHeadingID{ get; set; }
        public int AreasID { get; set; }
        public int HeadingID { get; set; }
        public string keyDescription { get; set; }
    }
}

   
