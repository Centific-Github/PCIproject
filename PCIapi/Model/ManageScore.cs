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
                return dbConnection.Query<mstScore>(sQuery, new { _strScoreCrdID = ID });
            }
        }
        public IEnumerable<mstScore> getScoresByAreas(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  ScoreCrdID, CeremID,AreasID,CompID,PcicmpID,HeadingID,ExcKeyActivityID,KeyActivitiesID,ActivityID,ScoreID,ScoreValue  from MstScore Where AreasID=@_strAreasID";
                dbConnection.Open();
                return dbConnection.Query<mstScore>(sQuery, new { _strAreasID = ID });
            }
        }
        public IEnumerable<mstScore> getScoresByKeyactivityHeading(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  ScoreCrdID, CeremID,AreasID,CompID,PcicmpID,HeadingID,ExcKeyActivityID,KeyActivitiesID,ActivityID,ScoreID,ScoreValue  from MstScore Where HeadingID=@_strHeadingID";
                dbConnection.Open();
                return dbConnection.Query<mstScore>(sQuery, new { _strHeadingID = ID });
            }
        }
        
        public IEnumerable<GetCeremony> getScoresByCeremonyDetails(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select mc.CeremDesc,mga.ActivityDesc,mcp.CompValue,s.ScoreValue
                 from MstScore s  
                 Join MstGovKeyActivity mga
                 on s.ActivityID=mga.ActivityID
                 Join MstCeremony mc
                 on s.CeremID=mc.CeremID
                 Join MstCompliance mcp on
                 s.CompID=mcp.CompID";
                dbConnection.Open();
                return dbConnection.Query<GetCeremony>(sQuery, new { _strCeremID = ID });
            }
        }

        public IEnumerable<excMaturity> getScoresByAreas(string Desc)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select mea.ExcKeyActivityDesc,mcp.CompValue,s.ScoreValue,msd.ScoreDesc
                 from MstScore s  
                 Join MstExcKeyActivities mea
                 on s.ExcKeyActivityID=mea.ExcKeyActivityID                 
                 Join MstCompliance mcp on
                 s.CompID=mcp.CompID
				 join MstScoreCriteria msd on
				 s.ScoreID=msd.ScoreID";
                dbConnection.Open();
                return dbConnection.Query<excMaturity>(sQuery, new { _strExcKeyActivityDesc = Desc });
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
        public int ExcKeyActivityID { get; set; }
        public int KeyActivitiesID { get; set; }
        public int ActivityID { get; set; }
        public int ScoreID { get; set; }
        public decimal ScoreValue { get; set; }
    }
    public class GetCeremony
    {
        public string ActivityDesc { get; set;}
        public string CompValue { get; set;}
      
        public decimal ScoreValue { get; set; }
    }
        public class excMaturity
        {
            public int ScoreCrdID { get; set; }
            public int AreasID { get; set; }
            public int ExcKeyActivityID { get; set; }
            public int CompID { get; set; }
            public int ScoreID { get; set; }
            public decimal ScoreValue { get; set; }
        }
    
}

