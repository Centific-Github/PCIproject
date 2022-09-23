using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Controllers
{
  /// <summary>
  /// following code is written by Monisree Sai Raji
  /// date : 20-09-2022
  /// <summary>

    [Route("api/[controller]")]
    [ApiController]
    public class ManageKeyAreasController : Controller
    {
        private IConfiguration _configuration;
        private ManageKeyAreas oManageKeyAreas ;

        public ManageKeyAreasController(IConfiguration configuration)
        {
            _configuration = configuration;
             oManageKeyAreas = new ManageKeyAreas(_configuration);

        }

        [HttpGet]
        public IEnumerable<keyAreas> get()
        {
            return oManageKeyAreas.getKeyAreaDeatails();
        }
        [HttpGet("{id}")]
        public IEnumerable<keyAreas> get(int id)
        {
            return oManageKeyAreas.getKeyAreaDeatails(id);
        }


    }
}
