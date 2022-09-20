using Dapper;
using System.Collections.Generic;
using System.Data;

namespace PCIapi.Model
{
    public class ManageKeyAreas : DBconnection
    {
        public IEnumerable<keyAreas> getKeyAreaDeatails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT AreasID, AreasDesc FROM MstKeyAreas";
                dbConnection.Open();
                return dbConnection.Query<keyAreas>(sQuery);
            }
        }
        public IEnumerable<keyAreas> getKeyAreaDeatails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT AreasID, AreasDesc FROM MstKeyAreas WHERE AreasID=@_AreasID";
                dbConnection.Open();
                return dbConnection.Query<keyAreas>(sQuery, new { _AreasID = id });
            }
        }

    }

    public class keyAreas
    {
        public int AreasID { get; set; }
        public string AreasDesc { get; set; }
    }
}
