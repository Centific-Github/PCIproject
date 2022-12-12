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
                    p.Add("PcicmpId", _scoreSave.PcicmpID);
                    p.Add("ActivityId", _scoreSave.ActivityId[i]);

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
                    return "The audit for same date is already submitted";
                }
            }
        }
        public IEnumerable<Score> GetScoreExc(int activityID, decimal complianceID)

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
        public IEnumerable<Score>GetScoreceremone(int activityID, int complianceID)



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
       
public IEnumerable<LatestAuditDetails> getLatestauditdetails(int ProjectID, int SaveType, int? AreasID,int PcicmpID)
        {
            using (IDbConnection dbConnection = Connection) 
            {
                var p = new DynamicParameters();
                p.Add("@ProjectID", ProjectID);
                p.Add("@SaveType", SaveType);
                p.Add("@AreasID", AreasID);
                p.Add("@PcicmpID", PcicmpID);
                dbConnection.Open();
                return dbConnection.Query<LatestAuditDetails>("GetAuditDetailBySaveDraft", p, commandType: CommandType.StoredProcedure); 
            }

        }
        public IEnumerable<Showdetails> GetShowDetails(int ProjectID, DateTime CreatedDate, int SaveType,  int PcicmpID  )
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
        public string InsertScore(Scores _scores)
        {
            using (IDbConnection dbConnection = Connection)
            {
                int affectedRows = 0;
                
                    var p = new DynamicParameters();
                    p.Add("ActivityID", _scores.ActivityID);
                    p.Add("AreasID", _scores.AreasID);
                    p.Add("PcicmpID", _scores.PcicmpID);
                    p.Add("ScoreValue", _scores.ScoreValue);
                    p.Add("CompID", _scores.CompID);
                    dbConnection.Open();
                    affectedRows += dbConnection.Execute("CreateUpdateScore", p, commandType: CommandType.StoredProcedure);
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
        public string InsertKeyActivities(AreasbyKeyActivities _AreasbyKeyActivities)
        {
            using (IDbConnection dbConnection = Connection)
            {
                int affectedRows = 0;

                var p = new DynamicParameters();
                p.Add("KeyActivities", _AreasbyKeyActivities.KeyActivities);
                p.Add("PcicmpID", _AreasbyKeyActivities.PcicmpID);
               
                dbConnection.Open();
                affectedRows += dbConnection.Execute("SP_InsertActivities", p, commandType: CommandType.StoredProcedure);
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

        public IEnumerable <ShowDetailsResponse> GetShowDetailsResponse(int ProjectID, DateTime CreatedDate, int SaveType, int PcicmpID)
        {
            var result = GetShowDetails(ProjectID, CreatedDate, SaveType, PcicmpID);
            var obj = new List<ShowDetailsResponse>();
            var objr = new ChildrenShowDetailsResponse();
            var objparent = new ShowDetailsResponse();
            string areadesc = "";
           
            string activityDesc = "";
           

            foreach (var record in result)

            {
                if (areadesc == "") 
                { 
                    areadesc = record.AreasDesc;
                    objparent.AreasDesc = areadesc;
                   activityDesc  = record.ActivityDesc;
                   objr.ActivityDesc = (activityDesc);
                    objr.CompValue = (record.CompValue);            
                     objr.ScoreValue = (record.ScoreValue);
                    objr.CreatedDate = (record.CreatedDate);
                    objparent.ChildrenShowDetails.Add(objr);
                    objparent.TotalScore += record.ScoreValue;
                    continue;
                }
                if (areadesc == record.AreasDesc)
                {
                    objr = new ChildrenShowDetailsResponse();
                    objr.ActivityDesc = (record.ActivityDesc);
                    objr.CompValue = (record.CompValue);
                    objr.ScoreValue = (record.ScoreValue);
                    objr.CreatedDate = (record.CreatedDate);
                    objparent.ChildrenShowDetails.Add(objr);
                    objparent.TotalScore += record.ScoreValue;
                } 
                else { obj.Add(objparent);
                   
                    areadesc = record.AreasDesc;
                    objr = new ChildrenShowDetailsResponse();
                    objparent = new ShowDetailsResponse();
                    objparent.AreasDesc = areadesc;
                    objr.ActivityDesc = (record.ActivityDesc);
                    objr.CompValue = (record.CompValue);
                    objr.ScoreValue = (record.ScoreValue);
                    objr.CreatedDate = (record.CreatedDate);
                    objparent.ChildrenShowDetails.Add(objr);
                    objparent.TotalScore += record.ScoreValue;
                }
            }
            
            
                obj.Add(objparent);
            
            return obj;



        }
        public IEnumerable<PciAreaModel> GetShowDetailsCategory()
        {
            using (IDbConnection dbConnection = Connection)
            {
               
               
                dbConnection.Open();
                return dbConnection.Query<PciAreaModel>("GetPcinamewithareas", commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<PciNamesWithAreaDesc> GetpcinameswithAreaDesc( )
        {
            var result = GetShowDetailsCategory();
            var obj = new List<PciNamesWithAreaDesc>();
            var objr = new List<ChildrenAreasList>();
            var objc = new ChildrenAreasList();
            var objparent = new PciNamesWithAreaDesc();
            string PcicmpName = "";


            foreach (var record in result)

            {
                if (PcicmpName == "")
                {
                    PcicmpName = record.PcicmpName;
                    objparent.PcicmpName = PcicmpName;
                    
                    objc.AreasDesc = (record.AreasDesc);
                    objr.Add(objc);
                    
                    continue;
                }
                if (PcicmpName == record.PcicmpName)
                {
                    
                    objc = new ChildrenAreasList();
                    objc.AreasDesc = (record.AreasDesc);
                    objr.Add(objc);

                }
                else
                {
                    
                    objparent.ChildrenShowDetails = objr;

                    obj.Add(objparent);

                    PcicmpName = record.PcicmpName;
                    objc = new ChildrenAreasList();
                    objr = new List<ChildrenAreasList>();

                    objparent = new PciNamesWithAreaDesc();
                    objparent.PcicmpName = PcicmpName;
                    objc.AreasDesc = (record.AreasDesc);
                    objr.Add(objc);
                    
                }
            }

            objparent.ChildrenShowDetails = objr;
            obj.Add(objparent);

            return obj;



        }
        public IEnumerable<PciActivityModel> GetShowDetailsKeyActivities()
        {
            using (IDbConnection dbConnection = Connection)
            {


                dbConnection.Open();
                return dbConnection.Query<PciActivityModel>("GetPcinamewithactivities", commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<PciNamesWithActivityDesc> GetpcinameswithActivityDesc()
        {
            var result = GetShowDetailsKeyActivities();
            var obj = new List<PciNamesWithActivityDesc>();
            var objr = new List<ChildrenActivityList>();
            var objc = new ChildrenActivityList();
            var objparent = new PciNamesWithActivityDesc();
            string PcicmpName = "";


            foreach (var record in result)

            {
                if (PcicmpName == "")
                {
                    PcicmpName = record.PcicmpName;
                    objparent.PcicmpName = PcicmpName;

                    objc.ActivitiesDesc = (record.ActivitiesDesc);
                    objr.Add(objc);

                    continue;
                }
                if (PcicmpName == record.PcicmpName)
                {

                    objc = new ChildrenActivityList();
                    objc.ActivitiesDesc = (record.ActivitiesDesc);
                    objr.Add(objc);

                }
                else
                {

                    objparent.ChildrenShowDetails = objr;

                    obj.Add(objparent);

                    PcicmpName = record.PcicmpName;
                    objc = new ChildrenActivityList();
                    objr = new List<ChildrenActivityList>();

                    objparent = new PciNamesWithActivityDesc();
                    objparent.PcicmpName = PcicmpName;
                    objc.ActivitiesDesc = (record.ActivitiesDesc);
                    objr.Add(objc);

                }
            }

            objparent.ChildrenShowDetails = objr;
            obj.Add(objparent);

            return obj;


        }

            public IEnumerable<ActivitiesByID> getActivitiesByID(int PcicmpID)
            {
                   using (IDbConnection dbConnection = Connection)
                   {
                     var p = new DynamicParameters();
                     p.Add("@PcicmpID", PcicmpID);
                     dbConnection.Open();
                     return dbConnection.Query<ActivitiesByID>("SP_GetActivities", p, commandType: CommandType.StoredProcedure);
                   }

            }
        public IEnumerable<ActivitiesByAreapcicmpID> getActivitiesByareaspcicmpID(int PcicmpID ,int AreasID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("@PcicmpID", PcicmpID);
                p.Add("@AreasID", AreasID);
                dbConnection.Open();
                return dbConnection.Query<ActivitiesByAreapcicmpID>("keyAreas_activities", p, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
  
    
    
    
    public class ScoreType
    {
        public int ProjectID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProjectManager { get; set; }
        public string SaveType { get; set; }

    }
    public class LatestAuditDetails
    {
        public int AreasID  { get; set; }
        public int  Activityid { get; set; }
        public int CompID { get; set; }
        public decimal ScoreValue { get; set; }
        



    }
    public class Scores
    {
        public int ActivityID { get; set; }
        public int AreasID { get; set; }
        public int PcicmpID { get; set; }
        public decimal ScoreValue { get; set; }
        public int CompID { get; set; }
    }

    public class AreasbyKeyActivities
    {
        public string KeyActivities { get; set; }
        public int PcicmpID { get; set; }
    }
public class ActivitiesByID
{
    public string KeyActivities { get; set; }
}
public class ActivitiesByAreapcicmpID
{
    public string Activitydesc { get; set; }
}






