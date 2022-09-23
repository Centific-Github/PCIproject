using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Controllers
{
    /// <summary>
    /// Following code has been written by:Jyothi
    /// Date:20-09-2022
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManageScoreCriteriaController : Controller
    {
        private readonly ManageScoreCriteria manageScoreCriteria;
        private IConfiguration _configuration;


        public ManageScoreCriteriaController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageScoreCriteria  = new ManageScoreCriteria(_configuration);
        }

        [HttpGet]
        public IEnumerable<scoreCriteria> get()
        {
            return manageScoreCriteria.getScoreCriteriaDetails();
        }
        [HttpGet("{id}")]
        public IEnumerable<scoreCriteria> get(int id)
        {
            return manageScoreCriteria.getScoreCriteriaDetails(id);
        }

    }
}
