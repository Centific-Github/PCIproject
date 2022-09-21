using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;

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

       
        public ManageScoreCriteriaController()
        {
            manageScoreCriteria  = new ManageScoreCriteria();
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
