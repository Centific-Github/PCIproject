using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

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
        public IEnumerable<Ceremony> getScoresByCeremonyDetails(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select distinct mga.ActivityID,mga.ActivityDesc
                 from MstScore s  
                 Join MstGovKeyActivity mga
                 on s.ActivityID=mga.ActivityID
                 Join MstCeremony mc
                 on s.CeremID=mc.CeremID
                 Where
                s. CeremID = @_strCeremID   ";
                dbConnection.Open();
                return dbConnection.Query<Ceremony>(sQuery, new { _strCeremID = ID });
            }
        }

        public IEnumerable<ExeMaturity> getScoresByexcmat(int ID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select  distinct mea.ExcKeyActivityID,mea.ExcKeyActivityDesc
                 from MstScore s 
				 join MstKeyAreas mka on
				 s.AreasID = mka.AreasID
                 Join MstExcKeyActivities mea
                 on s.ExcKeyActivityID=mea.ExcKeyActivityID 				 
                 where s.AreasID=@_strAreasID";
                dbConnection.Open();
                return dbConnection.Query<ExeMaturity>(sQuery, new { _strAreasID = ID });
            }
        }
        public IEnumerable<agileMaturityIndex> getScoresByAmiDetails(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select  distinct amid.KeyActivitiesID,amid.KeyActivitiesDesc
                 from MstScore amis  
                 Join MstKeyAreas ami
                 on amis.AreasID=ami.AreasID
                 Join MstAglMtyKeyActivities amid
                 on amis.KeyActivitiesID=amid.KeyActivitiesID
                  WHERE              
                ami.AreasID = @_strAreasID ";
                dbConnection.Open();
                return dbConnection.Query<agileMaturityIndex>(sQuery, new { _strAreasID = id });
            }
        }


        public string ScoreSave(ScoreSave _scoreSave)
        {
            using (IDbConnection dbConnection = Connection)
            {
                int affectedRows = 0;
                for (int i = 0; i < _scoreSave.ScoreCrdID.Length; i++)
                {
                    var p = new DynamicParameters();
                    p.Add("ProjectID", _scoreSave.ProjectID);
                    p.Add("saveType", _scoreSave.SaveType);
                    p.Add("ScoreCrdID", _scoreSave.ScoreCrdID[i]);
                    p.Add("CreatedDate", _scoreSave.Date);
                    dbConnection.Open();
                    affectedRows += dbConnection.Execute("sp_MstScoreSaveandUpdate", p, commandType: CommandType.StoredProcedure);
                    dbConnection.Close();
                }
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
        public IEnumerable<Score> GetScoreExc(int activityID, int complianceID)

        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ScoreCrdID, ScoreValue  from MstScore Where ExcKeyActivityID=@_strExcKeyActivityID and CompID=@_strCompID ";
                dbConnection.Open();
                return dbConnection.Query<Score>(sQuery, new { _strExcKeyActivityID = activityID, _strCompID = complianceID });
            }

        }
        public IEnumerable<Score> GetScoreAmi(int activityID, int complianceID)

        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ScoreCrdID, ScoreValue  from MstScore Where KeyActivitiesID=@_strKeyActivitiesID and CompID=@_strCompID";
                dbConnection.Open();
                return dbConnection.Query<Score>(sQuery, new { _strKeyActivitiesID = activityID, _strCompID = complianceID });
            }

        }
        public IEnumerable<Score> GetScoreceremone(int activityID, int complianceID)



        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT ScoreCrdID, ScoreValue  from MstScore Where ActivityID=@_strActivityID and CompID=@_strCompID";
                dbConnection.Open();
                return dbConnection.Query<Score>(sQuery, new { _strActivityID = activityID, _strCompID = complianceID });
            }



        }
        public IEnumerable<ScoreType> getAuditListDetails(string ProjectName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT tps.CreatedDate,pm.ProjectManager,tps.SaveType,pm.ProjectID
                                FROM [dbo].[MstProjectMaster] pm
                                JOIN [dbo].[TrnsProjectScore] tps
                                ON pm.ProjectID=tps.ProjectID
                                WHERE pm.ProjectName=@_strprojectName                                
                                GROUP BY tps.CreatedDate,pm.ProjectManager,tps.SaveType,pm.ProjectID
                                ORDER BY tps.CreatedDate";
                dbConnection.Open();
                return dbConnection.Query<ScoreType>(sQuery, new { _strprojectName = ProjectName });
            }
        }
       
public IEnumerable<LatestAuditDetails> getLatestauditdetails(int ProjectID, int SaveType, int? AreasID)
        {
            using (IDbConnection dbConnection = Connection) 
            {
                var p = new DynamicParameters();
                p.Add("@ProjectID", ProjectID);
                p.Add("@SaveType", SaveType);
                p.Add("@AreasID", AreasID);
                dbConnection.Open();
                return dbConnection.Query<LatestAuditDetails>("GetAuditDetailBySaveDraft", p, commandType: CommandType.StoredProcedure); 
            }

        }
        public IEnumerable<Showdetails> GetShowDetails(int ProjectID, DateTime CreatedDate, int SaveType, int PcicmpID)



        {
            using (IDbConnection dbConnection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@ProjectID", ProjectID);
                p.Add("@SaveType", SaveType);
                p.Add("@CreatedDate", CreatedDate);
                p.Add("@PcicmpID", PcicmpID);
                dbConnection.Open();
                return dbConnection.Query<Showdetails>("sp_showDetails", p, commandType: CommandType.StoredProcedure);
            }
        }


        



    }
    public class ScoreType
    {

        public DateTime CreatedDate { get; set; }
        public string ProjectManager { get; set; }
        public string SaveType { get; set; }

    }
    public class LatestAuditDetails
    {
        public int AreasID { get; set; }
        public int ExcKeyActivityID { get; set; }
        public int CompID { get; set; }
        public decimal ScoreValue { get; set; }



    }
}





