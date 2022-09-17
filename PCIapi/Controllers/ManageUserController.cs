using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserController : ControllerBase
    {
        private readonly ManageUsers manageUsers;
        public ManageUserController()
        {
            manageUsers = new ManageUsers();
        }
        [HttpGet]
        public IEnumerable<userType> get()
        {
            return manageUsers.getUsers();
        }
        [HttpPost]
        public userType validateLogin(userType _userType)
        {
            if (manageUsers.getUsers(_userType) == null)
            {
                userType ouserType = new userType();
                return ouserType;
            }

            else
                return manageUsers.getUsers(_userType);
        }
    }
}
