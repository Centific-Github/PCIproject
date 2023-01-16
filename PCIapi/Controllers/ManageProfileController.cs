using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
using System.Collections.Generic;

namespace PCIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageProfileController : ControllerBase
    {

        private IConfiguration _configuration;
        private readonly ManageProfile manageProfile;
        public ManageProfileController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageProfile = new ManageProfile(_configuration);
        }
        [HttpGet]
        public IEnumerable<ManageProfileViewModel> Get()
        {
            return manageProfile.getProfileDetails();
        }
    }
}
