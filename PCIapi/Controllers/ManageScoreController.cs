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
            public IEnumerable<mstScore> get()
            {
                return manageScoreController.getMstScoreDetails();
            }       

        [HttpGet("{id}")]
            public IEnumerable<mstScore> get(int id)
            {
            return manageScoreController.getMstScoreDetails(id);
        }  
        [HttpGet]
        [Route("ScoresByAreas")]
        public IEnumerable<mstScore>getScoresByAreas(int id)
        {
            return manageScoreController.getScoresByAreas(id);
        }
        [HttpGet]
        [Route("ScoresByKeyactivityHeading")]
        public IEnumerable<mstScore> getScoresByKeyactivityHeading(int id)
        {
            return manageScoreController.getScoresByKeyactivityHeading(id);
        }

        [HttpGet]
        [Route("ScoresByCeremony")]
        public IEnumerable<GetCeremony> getScoresByCeremonyDetails(int ID)
        {
            return manageScoreController.getScoresByCeremonyDetails(ID);
        }
    }
}

