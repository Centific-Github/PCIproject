using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace PCIapi.Controllers
{
    /// <summary>
    /// Following code was written by: Rajib Basu
    /// Date:20-Sept-2022
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManagePciCmpController : Controller
    {
        private IConfiguration _configuration;
        private readonly ManagePciCmp managePciCmp;
        public ManagePciCmpController(IConfiguration configuration)
        {
            _configuration = configuration;
            managePciCmp = new ManagePciCmp(_configuration);
        }
        [HttpGet]
        public IEnumerable<pciCmp> get()
        {
            return managePciCmp.getPciDetails();
        }

        [HttpGet("{id}")]
        public IEnumerable<pciCmp> get(int id)
        {
            return managePciCmp.getPciDetails(id);
        }
    }
}
