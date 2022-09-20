using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;

namespace PCIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageKeyAreasController : Controller
    {
        ManageKeyAreas oManageKeyAreas = new ManageKeyAreas();
        //public IActionResult Index()
        //{
        //    return View();
        //}
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
