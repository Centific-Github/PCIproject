using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace PCIapi.Model
{
    /// <summary>
    /// Following code has been written by :Jyothi
    /// Date:20-09-2022
    /// </summary>
    public class ManageScoreCriteria : DBconnection
    {
        public IEnumerable<scoreCriteria> getScoreCriteriaDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ScoreID,ScoreDesc FROM MstScoreCriteria";
                dbConnection.Open();
                return dbConnection.Query<scoreCriteria>(sQuery);
            }
        }

        

        public IEnumerable<scoreCriteria> getscoreCriteriaDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ScoreID,ScoreDesc FROM MstScoreCriteria  WHERE ScoreID =@_ScoreID";
                dbConnection.Open();
                return dbConnection.Query<scoreCriteria>(sQuery, new { _ScoreID = id });
            }
        }

    }
    public class scoreCriteria
    {
        public int ScoreID { get; set; }
        public string ScoreDesc { get; set; }
    }
}
