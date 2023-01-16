using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
using System;
using System.Collections.Generic;


namespace PCIapi.Controllers
/// <summary>
/// following code has written by velpula Pushpa
/// date 28/09/2022
/// </summary>
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageScoreController : Controller
    {
        private IConfiguration _configuration;


        private readonly ManageScore manageScoreController;
        public ManageScoreController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageScoreController = new ManageScore(_configuration);
        }
        [HttpGet]
        public IEnumerable<MstScore> get()
        {
            return manageScoreController.getMstScoreDetails();
        }

        [HttpGet("{id}")]
        public IEnumerable<MstScore> get(int id)
        {
            return manageScoreController.getMstScoreDetails(id);
        }
        [HttpGet]
        [Route("ScoresByAreas")]
        public IEnumerable<MstScore> getScoresByAreas(int id)
        {
            return manageScoreController.getScoresByAreas(id);
        }
        [HttpGet]
        [Route("ScoresByKeyactivityHeading")]
        public IEnumerable<MstScore> getScoresByKeyactivityHeading(int id)
        {
            return manageScoreController.getScoresByKeyactivityHeading(id);
        }


        [HttpGet]
        [Route("ScoresByCeremony")]
        public IEnumerable<Ceremony> GetScoresByCeremonyDetails(int ID)
        {
            return manageScoreController.getScoresByCeremonyDetails(ID);
        }
        [HttpGet]
        [Route("ScoresByAmi")]
        public IEnumerable<agileMaturityIndex> getScoresByAmiDetails(int id)
        {
            return manageScoreController.getScoresByAmiDetails(id);
        }


        [HttpGet]
        [Route("ScoresByExcmat")]
        public IEnumerable<ExeMaturity> getScoresByexcmat(int areasID)
        {
            return manageScoreController.getScoresByexcmat(areasID);
        }
        [HttpPost]
        [Route("MstScoreSave")]
        public string Insert([FromBody] ScoreSave _scoreSave)
        {
            if (ModelState.IsValid)
            {
                if (_scoreSave == null)
                {
                    return "please pass the parameter";
                }
                else
                {
                    var affectedRows = manageScoreController.ScoreSave(_scoreSave);
                    return affectedRows;
                }
            }
            else
                return "Invalid model";
        }

        [HttpGet]
        [Route("GetScoreExm")]
        public IEnumerable<Score> GetScoreExc(int activityID, decimal complianceID)
        {
            return manageScoreController.GetScoreExc(activityID, complianceID);
        }
        [HttpGet]
        [Route("GetScoreAmi")]
        public IEnumerable<Score> GetScoreAmi(int activityID, int complianceID)
        {
            return manageScoreController.GetScoreAmi(activityID, complianceID);
        }

        [HttpGet]
        [Route("GetScoreceremone")]
        public IEnumerable<Score> GetScoreCeremone(int activityID, int complianceID)
        {
            return manageScoreController.GetScoreceremone(activityID, complianceID);
        }
        [HttpGet]
        [Route("ScoresBykeyActivities")]
        public IEnumerable<Scorebyactivity> getscorevaluebyactivities(int Activityid, decimal Complianceid)
        {
            return manageScoreController.getscorevaluebyactivities(Activityid, Complianceid);
        }
        [HttpGet]
        [Route("Projectname")]
        public IEnumerable<ScoreType> getAuditListDetails(string ProjectName)
        {
            return manageScoreController.getAuditListDetails(ProjectName);
        }
        [HttpGet]
        [Route("LatestAuditlist")]
        public IEnumerable<LatestAuditDetails> getLatestauditdetails(int ProjectID, int SaveType, int? AreasID, int PcicmpID)
        {
            return manageScoreController.getLatestauditdetails(ProjectID, SaveType, AreasID, PcicmpID);
        }
        [HttpGet]
        [Route("GetShowdetailsResponse")]
        public IEnumerable<ShowDetailsResponse> GetShowDetailsResponse(int ProjectID, DateTime CreatedDate, int SaveType, int PcicmpID)
        {
            return manageScoreController.GetShowDetailsResponse(ProjectID, CreatedDate, SaveType, PcicmpID);
        }
        [HttpGet]
        [Route("Getshowdetails")]
        public IEnumerable<PciNamesWithAreaDesc> GetShowDetails()
        {
            return manageScoreController.GetpcinameswithAreaDesc();
        }
        [HttpGet]
        [Route("GetshowdetailsByKeyActivities")]
        public IEnumerable<PciNamesWithActivityDesc> GetDetailsbyKeyActivities()
        {
            return manageScoreController.GetpcinameswithActivityDesc();
        }
        [HttpPost]
        [Route("InsertScore")]
        public string InsertScore([FromBody] Scores _scores)
        {
            if (ModelState.IsValid)
            {
                if (_scores == null)
                {
                    return "please pass the parameter";
                }
                else
                {
                    return manageScoreController.InsertScore(_scores);

                }
            }
            else
                return "Invalid model";
        }
        [HttpPost]
        [Route("InsertKeyActivities")]
        public string InsertKeyActivities([FromBody] AreasbyKeyActivities _AreasbyKeyActivities)
        {
            if (ModelState.IsValid)
            {
                if (_AreasbyKeyActivities == null)
                {
                    return "please pass the parameter";
                }
                else
                {
                    return manageScoreController.InsertKeyActivities(_AreasbyKeyActivities);

                }
            }
            else
                return "Invalid model";
        }
        [HttpGet]
        [Route("ActivitiesbypcicmpID")]
        public IEnumerable<ActivitiesByID> getActivitiesByID(int PcicmpID)
        {
            return manageScoreController.getActivitiesByID(PcicmpID);
        }
        [HttpGet]
        [Route("ActivitiesbyareaspcicmpID")]
        public IEnumerable<ActivitiesByAreapcicmpID> getActivitiesByareaspcicmpID(int PcicmpID, int AreasID)
        {
            return manageScoreController.getActivitiesByareaspcicmpID(PcicmpID, AreasID);
        }
        [HttpPost]
        [Route("MstScore")]
        public string Insert([FromBody] MstScoreSave _scoreSave)
        {
            if (ModelState.IsValid)
            {
                if (_scoreSave == null)
                {
                    return "please pass the parameter";
                }
                else
                {
                    var affectedRows = manageScoreController.MstScore(_scoreSave);
                    return affectedRows;
                }
            }
            else
                return "Invalid model";
        }
    }
}

