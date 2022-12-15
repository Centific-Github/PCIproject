using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;

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

        public string InsertKeyareas(InsertKeyAreas _insertKeyAreas)
        {
            using (IDbConnection dbConnection = Connection)
            {
                int affectedRows = 0;

                var p = new DynamicParameters();
                p.Add("AreasDesc", _insertKeyAreas.AreasDesc);
                p.Add("PcicmpID", _insertKeyAreas.PcicmpID);

                dbConnection.Open();
                affectedRows += dbConnection.Execute("InsertKeyAreas", p, commandType: CommandType.StoredProcedure);
                dbConnection.Close();

                if (affectedRows > 0)
                {
                    return " Saved Data Successful";

                }
                else
                {
                    return "Issuing the data";
                }
            }
        }
        public IEnumerable<AreasbyID> getAreasByID(int PcicmpID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@PcicmpID", PcicmpID);
                dbConnection.Open();
                return dbConnection.Query<AreasbyID>("Sp_GetAreas", p, commandType: CommandType.StoredProcedure);
            }

        }
        public string getcheckingKeyAreas(string AreasDesc)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select 1 from  MstKeyAreas  where AreasDesc = @_strAreasDesc";
                dbConnection.Open();
                var result = dbConnection.Query<string>(sQuery, new { _strAreasDesc = AreasDesc });
                if (result.Count() > 0)
                {
                    return "KeyArea exist";
                }
                else
                {
                    return "KeyArea doesnot exist";
                }
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
        public int PcicmpID { get; set; }
    }
    public class AreasbyID
    {
        public int AreasID { get; set; }
        public string AreasDesc { get; set; }
       

    }
}
