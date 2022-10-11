//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using PCIapi.Model;
//using System;
//using System.Collections.Generic;

//namespace PCIapi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ExcmrtController : Controller
//    {
//        private IConfiguration _configuration;
//        private readonly Excmrt excmrtController;
//        public ExcmrtController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//            excmrtController = new Excmrt(_configuration);
//        }
//        [HttpGet]
//        public IEnumerable<mstSubActivityMaster> get()
//        {
//            return ExcmrtController.getmstSubActivityMasterDetails();
//        }       
//        [HttpGet("{id}")]
//        public IEnumerable<mstSubActivityMaster> get(int id)
//        {
//            return ExcmrtController.getmstSubActivityMasterDetails(id);
//        }
//    }
//}
    