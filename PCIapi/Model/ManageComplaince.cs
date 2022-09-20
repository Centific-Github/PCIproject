using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PCIapi.Model
{
    public class ManageMstCompliance : DBconnection
    {
        //internal static object getComplianceDetails(mstComplaince mstComplaince)
        //{
        //    throw new NotImplementedException();
        //}

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