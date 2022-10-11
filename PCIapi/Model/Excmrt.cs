//using Dapper;
//using Microsoft.Extensions.Configuration;
//using System.Collections.Generic;
//using System.Data;

//namespace PCIapi.Model
//{
    
    
//        public class Excmrt : DBconnection
//        {
//            public Excmrt(IConfiguration configuration) : base(configuration)
//            {

//            }

//            public IEnumerable<mstSubActivityMaster> getmstSubActivityMasterDetails()
//            {
//                using (IDbConnection dbConnection = Connection)
//                {

//                    string sQuery = @"SELECT  SubHeadingID, AreasID,HeadingID,keyDescription  from MstSubActivityMaster";
//                    dbConnection.Open();
//                    return dbConnection.Query<mstSubActivityMaster>(sQuery);
//                }
//            }
//            public IEnumerable<mstSubActivityMaster> getMstScoreDetails(int ID)
//            {
//                using (IDbConnection dbConnection = Connection)
//                {
//                    string sQuery = @"SELECT  SubHeadingID, CeremID,AreasID,CompID,PcicmpID,HeadingID,ExcKeyActivityID,KeyActivitiesID,ActivityID,ScoreID,ScoreValue  from MstScore Where SubHeadingID=@_strSubHeadingID";
//                    dbConnection.Open();
//                    return dbConnection.Query<mstSubActivityMaster>(sQuery, new { _strSubHeadingID = ID });
//                }
//            }

//        }
//    public class mstSubActivityMaster
//    {
//        public int SubHeadingID { get; set; }
//        public int AreasID { get; set; }
//        public int HeadingID { get; set; }
//        public int keyDescription { get; set; }
//    }      
    
//}
