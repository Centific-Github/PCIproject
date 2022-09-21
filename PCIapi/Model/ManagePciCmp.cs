using Dapper;
using System.Collections.Generic;
using System.Data;

namespace PCIapi.Model
{
    /// <summary>
    /// This code has been written by Rajib Basu
    /// Date: 19-Sept-2022
    /// </summary>
    public class ManagePciCmp : DBconnection
    {
        public IEnumerable<pciCmp> getPciDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT PcicmpID, PcicmpName FROM MstPcicmp";
                dbConnection.Open();
                return dbConnection.Query<pciCmp>(sQuery);
            }
        }
        public IEnumerable<pciCmp> getPciDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT PcicmpID, PcicmpName FROM MstPcicmp WHERE PcicmpID=@_PcicmpID";
                dbConnection.Open();
                return dbConnection.Query<pciCmp>(sQuery, new { _PcicmpID = id });
            }
        }
    }

    public class pciCmp
    {
        public int PcicmpID { get; set; }
        public string PcicmpName { get; set; }
    }
}
