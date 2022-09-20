using Dapper;
using System.Collections.Generic;
using System.Data;

namespace PCIapi.Model
{
    /// <summary>
    /// Following code was written by: Sumalatha
    /// Date:20-Sept-2022
    /// </summary>
    /// 
    public class ManageAglMtyHeading : DBconnection
    {
        public IEnumerable<aglMtyHeading> getHeadingDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT HeadingID, HeadingDesc FROM MstAglMtyHeading";
                dbConnection.Open();
                return dbConnection.Query<aglMtyHeading>(sQuery);
            }
        }
        public IEnumerable<aglMtyHeading> getHeadingDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT HeadingID, HeadingDesc FROM MstAglMtyHeading WHERE HeadingID=@_HeadingID";
                dbConnection.Open();
                return dbConnection.Query<aglMtyHeading>(sQuery, new { _HeadingID = id });
            }
        }
    }

    public class aglMtyHeading
    {
        public int HeadingID { get; set; }
        public string HeadingDesc { get; set; }
    }
}
