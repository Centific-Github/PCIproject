using Dapper;
using Microsoft.Extensions.Configuration;
using System;
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

        public IEnumerable<MstScore> getMstScoreDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {

                string sQuery = @"SELECT  ScoreCrdID, CeremID,AreasID,CompID,PcicmpID,HeadingID,ExcKeyActivityID,KeyActivitiesID,ActivityID,ScoreID,ScoreValue  from MstScore";
                dbConnection.Open();
                return dbConnection.Query<MstScore>(sQuery);
            }
        }
        public IEnumerable<MstScore> getMstScoreDetails(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  ScoreCrdID, CeremID,AreasID,CompID,PcicmpID,HeadingID,ExcKeyActivityID,KeyActivitiesID,ActivityID,ScoreID,ScoreValue  from MstScore Where ScoreCrdID=@_strScoreCrdID";
                dbConnection.Open();
                return dbConnection.Query<MstScore>(sQuery, new { _strScoreCrdID = ID });
            }
        }
        public IEnumerable<MstScore> getScoresByAreas(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  ScoreCrdID, CeremID,AreasID,CompID,PcicmpID,HeadingID,ExcKeyActivityID,KeyActivitiesID,ActivityID,ScoreID,ScoreValue  from MstScore Where AreasID=@_strAreasID";
                dbConnection.Open();
                return dbConnection.Query<MstScore>(sQuery, new { _strAreasID = ID });
            }
        }
        public IEnumerable<MstScore> getScoresByKeyactivityHeading(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  ScoreCrdID, CeremID,AreasID,CompID,PcicmpID,HeadingID,ExcKeyActivityID,KeyActivitiesID,ActivityID,ScoreID,ScoreValue  from MstScore Where HeadingID=@_strHeadingID";
                dbConnection.Open();
                return dbConnection.Query<MstScore>(sQuery, new { _strHeadingID = ID });
            }
        }

        public IEnumerable<ExeMaturity> getScoresByexcmat(int  ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select mka.AreasDesc,mea.ExcKeyActivityDesc,mcp.CompValue,msd.ScoreDesc,s.ScoreValue
                 from MstScore s 
				 join MstKeyAreas mka on
				 s.AreasID = mka.AreasID
                 Join MstExcKeyActivities mea
                 on s.ExcKeyActivityID=mea.ExcKeyActivityID 				 
                 Join MstCompliance mcp on
                 s.CompID=mcp.CompID
				 join MstScoreCriteria msd on
				 s.ScoreID=msd.ScoreID where s.AreasID=@_strAreasID";
                dbConnection.Open();
                return dbConnection.Query<ExeMaturity>(sQuery, new { _strAreasID = ID });
            }
        }
        public IEnumerable<agileMaturityIndex> getScoresByAmiDetails(int id, int Headingid)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select ami.AreasDesc,amih.HeadingDesc,amid.KeyActivitiesDesc,amicp.CompValue,amisd.ScoreDesc,amis.ScoreValue
                 from MstScore amis  
                 Join MstKeyAreas ami
                 on amis.AreasID=ami.AreasID
                 Join MstAglMtyHeading amih
                 on amis.HeadingID=amih.HeadingID
                 Join MstAglMtyKeyActivities amid
                 on amis.KeyActivitiesID=amid.KeyActivitiesID
                 Join MstCompliance amicp on
                 amis.CompID=amicp.CompID
                 Join MstScoreCriteria amisd on
                 amis.ScoreID = amisd.ScoreID
                  WHERE              
                ami.AreasID = @_strAreasID AND
                amih.HeadingID = @_strHeadingID";



                dbConnection.Open();
                return dbConnection.Query<agileMaturityIndex>(sQuery, new { _strAreasID = id, _strHeadingID = Headingid });
            }
        }
        

        public string ScoreSave(ScoreSave _scoreSave)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO MstScoreCalculation (ProjectID,PcicmpID,ScoreCrdID,CreatedDate,Date )  values(@_strProjectID,@_strPcicmpID,@_strScoreCrdID,GETDATE(),@_strDate)";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strProjectID = _scoreSave.ProjectID, _strPcicmpID = _scoreSave.PcicmpID, _strScoreCrdID = _scoreSave.ScoreCrdID, _strDate = _scoreSave.Date });
                if (affectedRows > 0)
                {
                    return " Saved Data Successful";

                }
                else
                {
                    return "Issuing Saving the Data";
                }

            }
        }
       
       
        
       
    }
}

