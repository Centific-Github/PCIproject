using static PCIapi.Model.ManageMstCompliance;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Model
{
    /// <summary>
    ///  following code has written by velpula Pushpa
    /// date 20/09/2022
    /// </summary>
    public class ManageCeremony : DBconnection
    {
        public ManageCeremony(IConfiguration configuration) : base(configuration)
        {

        }
            public IEnumerable<mstCeremony> getMstComplianceDetails()
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"SELECT CeremID, CeremDesc FROM MstCeremony";
                    dbConnection.Open();
                    return dbConnection.Query<mstCeremony>(sQuery);
                }
            }
        public IEnumerable<mstCeremony> getMstComplianceDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT CeremID, CeremDesc from MstCeremony WHERE CompID=@_CompID";
                dbConnection.Open();
                return dbConnection.Query<mstCeremony>(sQuery, new { _CompID = id });
            }
        }


    }
    public class mstCeremony
        {
            public int CeremID { get; set; }
            public string CeremDesc { get; set; }
        }
    }

