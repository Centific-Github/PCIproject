﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
using System.Collections.Generic;
using static PCIapi.Model.ManageUsers;

namespace PCIapi.Controllers
{
    /// <summary>
    /// Following code has been written by: rajib Basu
    /// date: 19-Sept-2022
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserController : ControllerBase
    {
        private IConfiguration _configuration;

        private readonly ManageUsers manageUsers;
        public ManageUserController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageUsers = new ManageUsers(_configuration);
        }
        [Authorize]

        [HttpGet]
        public IEnumerable<userType> get()
        {
            return manageUsers.getUsers();
        }
        [HttpGet("{id}")]
        public userType get(int id)
        {
            return manageUsers.getUsers(id);
        }

        //[HttpPost]
        //public userType post([FromBody] userType _userType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_userType == null)
        //        {
        //            userType ouserType = new userType();
        //            return ouserType;
        //        }
        //        else
        //        {
        //            _userType = manageUsers.getUsers(_userType);
        //            return userType;
        //        }
        //    }
        //    else
        //        return null;
        //}
        [HttpPost]
        [Route("insert")]
        public int Insert([FromBody] userTypeDTO _userTypeDto)
        {
            if (ModelState.IsValid)
            {
                if (_userTypeDto == null)
                {



                    return 0;
                }
                else
                {
                    var affectedRows = manageUsers.insertUsers(_userTypeDto);
                    return affectedRows;
                }
            }
            else
                return 0;
        }
        

        //[Authorize]

        //[HttpPut("{id}")]
        //public bool Put(int id, [FromBody] userType _userType)
        //{
        //    if (manageUsers.getUsers(_userType) == null)
        //    {
        //        // update statement
        //    }
        //    return true;
        //}
        
        [HttpGet]
        [Route("CheckEmailId")]
        public string CheckEmailId( string CheckEmailId)
        {
          
              return manageUsers.getcheckingEmailID(CheckEmailId);
             
               
        }
        
        [HttpGet]

        [Route("CheckUserName")]
        public string CheckUserName(string CheckUserName)
        {

            return manageUsers.getcheckingUserName(CheckUserName);


        }
        [Authorize]
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return true;
        }
    }
}

