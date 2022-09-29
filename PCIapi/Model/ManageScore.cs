using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace PCIapi.Model
/// <summary>
/// following code has written by velpula Pushpa
/// date 28/09/2022
/// </summary>
{
    public class ManageScore : DBconnection
    {
        public ManageScore(IConfiguration configuration) : base(configuration)
        {

        }    

        public IEnumerable<mstScore> getMstScoreDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {

                string sQuery = @"SELECT  ScoreCrdID, CeremID,AreasID,CompID,PcicmpID,HeadingID,ExcKeyActivityID,KeyActivitiesID,ActivityID,ScoreID,ScoreValue  from MstScore";
                dbConnection.Open();
                return dbConnection.Query<mstScore>(sQuery);
            }
        }
        public IEnumerable<mstScore> getMstScoreDetails(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  ScoreCrdID, CeremID,AreasID,CompID,PcicmpID,HeadingID,ExcKeyActivityID,KeyActivitiesID,ActivityID,ScoreID,ScoreValue  from MstScore Where ScoreCrdID=@_strScoreCrdID";
                dbConnection.Open();
                return dbConnection.Query<mstScore>(sQuery, new { _strScoreCrdID = ID});
            }
        }

    }    
        public class mstScore
        {
            public int ScoreCrdID { get; set; }
            public int CeremID { get; set; }
            public int AreasID { get; set; }
            public int CompID { get; set; }
            public int PcicmpID { get; set; }
            public int HeadingID { get; set; }
            public int ExcKeyActivityID {get; set; }
            public int KeyActivitiesID { get; set; }
            public int ActivityID { get; set; }
            public int ScoreID { get; set; }
            public decimal ScoreValue { get; set; }
        }
}

