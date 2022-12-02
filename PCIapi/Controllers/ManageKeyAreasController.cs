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
        
        [HttpPost]
        [Route("InsertKeyareas")]
        public string InsertKeyareas([FromBody] InsertKeyAreas _insertKeyAreas)
        {
            if (ModelState.IsValid)
            {
                if (_insertKeyAreas == null)
                {
                    return "please pass the parameter";
                }
                else
                {
                    return oManageKeyAreas.InsertKeyareas(_insertKeyAreas);

                }
            }
            else
                return "Invalid model";
        }
        [HttpGet]
        [Route("AreasbypcicmpID")]
        public IEnumerable<AreasbyID> getAreasByID(int PcicmpID)
        {
            return oManageKeyAreas.getAreasByID(PcicmpID);
        }
    }
}
