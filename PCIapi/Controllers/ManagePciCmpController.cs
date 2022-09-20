using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;

namespace PCIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagePciCmpController : Controller
    {
        private readonly ManagePciCmp managePciCmp;
        public ManagePciCmpController()
        {
            managePciCmp = new ManagePciCmp();
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
