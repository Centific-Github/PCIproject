using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;

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
        ManageKeyAreas oManageKeyAreas = new ManageKeyAreas();
       
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
