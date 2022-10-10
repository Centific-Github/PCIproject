using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Controllers
{
    /// <summary>
    /// Following code was written by: Sumalatha
    /// Date:20-Sept-2022
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManageAglMtyHeadingController : Controller
    {
        private IConfiguration _configuration;
        private readonly ManageAglMtyHeading manageAglMtyHeading;
        public ManageAglMtyHeadingController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageAglMtyHeading = new ManageAglMtyHeading(_configuration);
        }
        [HttpGet]
        public IEnumerable<agileMaturity> get()
        {
            return manageAglMtyHeading.getHeadingDetails();
        }

        [HttpGet("{id}")]
        public IEnumerable<agileMaturity> get(int id)
        {
            return manageAglMtyHeading.getHeadingDetails(id);
        }
    }
}
