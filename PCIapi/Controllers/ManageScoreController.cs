using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
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
        public IEnumerable<MstScore>getScoresByAreas(int id)
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
        public IEnumerable<Ceremony> getScoresByCeremonyDetails(int ID)
        {
            return manageScoreController.getScoresByCeremonyDetails(ID);
        }


        [HttpGet]
        [Route("ScoresByExcmat")]
        public IEnumerable<ExeMaturity> getScoresByAreas(string Desc)
        {
            return manageScoreController.getScoresByAreas(Desc);
        }
        [HttpGet]
        [Route("ScoresByAmi")]
        public IEnumerable<agileMaturityIndex> getScoresByAmiDetails(int id, int Headingid)
        {
            return manageScoreController.getScoresByAmiDetails(id, Headingid);
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


    }
}

