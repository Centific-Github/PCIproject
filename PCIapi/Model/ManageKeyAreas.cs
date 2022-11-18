using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Model
{
  /// <summary>
  /// following code is written by Monisree Sai Raji
  /// date : 20-09-2022
  /// <summary>
  
    public class ManageKeyAreas : DBconnection
    {
        public ManageKeyAreas(IConfiguration configuration) : base(configuration)
        {

        }
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
        public int insertkeyareas(InsertKeyAreas _insertKeyAreas)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO MstKeyAreas ( AreasDesc)  values(@_strAreasDesc)";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strAreasDesc = _insertKeyAreas.AreasDesc});
                return affectedRows;

            }

        }

    }

    public class keyAreas
    {
        public int AreasID { get; set; }
        public string AreasDesc { get; set; }
    }

    public class InsertKeyAreas
    {
        public string AreasDesc { get; set; }
    }
}
