using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace PCIapi.Model
{
    /// <summary>
    /// This code has been written by Rajib Basu
    /// Date: 19-Sept-2022
    /// </summary>
    public class ManagePciCmp : DBconnection
    {
        public ManagePciCmp(IConfiguration configuration) : base(configuration)
        {

        }
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
        public int insertPcicmpDetails(pcicmpi _Pcicmp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO MstPcicmp (PcicmpName )  values(@_strPcicmpName)";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strPcicmpName = _Pcicmp.PcicmpName });
                return affectedRows;

            }

        }
        public string getcheckingPcicmpName(string PcicmpName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select 1 from  MstPcicmp  where PcicmpName = @_strPcicmpName";
                dbConnection.Open();
                var result = dbConnection.Query<int>(sQuery, new { _strPcicmpName = PcicmpName });
                if (result.Count() > 0)
                {
                    return "PcicmpName exist";
                }
                else
                {
                    return "PcicmpName doesnot exist";
                }
            }

        }
    }

    public class pciCmp
    {
        public int PcicmpID { get; set; }
        public string PcicmpName { get; set; }
    }
    public class pcicmpi
    {
        public string PcicmpName { get; set; }  
    }
}
