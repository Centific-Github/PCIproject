using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PCIapi.Model
{
    /// <summary>
    /// following code has written by velpula Pushpa
    /// date 20/09/2022
    /// </summary>
    public class ManageMstCompliance : DBconnection
    {
        public IEnumerable<mstCompliance> getMstComplianceDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT CompID, CompValue FROM MstCompliance";
                dbConnection.Open();
                return dbConnection.Query<mstCompliance>(sQuery);
            }
        }
        public IEnumerable<mstCompliance> getMstComplianceDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT CompID, CompValue from MstCompliance WHERE CompID=@_CompID";
                dbConnection.Open();
                return dbConnection.Query<mstCompliance>(sQuery , new { _CompID =id});
            }
        }

        public class mstCompliance
        {
            public int CompID { get; set; }

            public string CompValue { get; set; }
        }
    }
}