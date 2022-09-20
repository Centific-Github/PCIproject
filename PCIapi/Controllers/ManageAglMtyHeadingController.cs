using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;

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
        private readonly ManageAglMtyHeading manageAglMtyHeading;
        public ManageAglMtyHeadingController()
        {
            manageAglMtyHeading = new ManageAglMtyHeading();
        }
        [HttpGet]
        public IEnumerable<aglMtyHeading> get()
        {
            return manageAglMtyHeading.getHeadingDetails();
        }

        [HttpGet("{id}")]
        public IEnumerable<aglMtyHeading> get(int id)
        {
            return manageAglMtyHeading.getHeadingDetails(id);
        }
    }
}
