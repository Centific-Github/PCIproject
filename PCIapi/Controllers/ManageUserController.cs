﻿using Microsoft.AspNetCore.Mvc;
using PCIapi.Model;
using System.Collections.Generic;

namespace PCIapi.Controllers
{
    /// <summary>
    /// Following code has been written by: raib Basu
    /// date: 19-Sept-2022
    /// </summary>
    /// 
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
        [HttpGet("{id}")]
        public userType get(int id)
        {
            return manageUsers.getUsers(id);
        }
        [HttpPost]
        public userType Post([FromBody] userType _userType)
        {
            if (ModelState.IsValid)
            {
                if (_userType == null)
                {
                    userType ouserType = new userType();
                    return ouserType;
                }

                else
                {
                    _userType = manageUsers.getUsers(_userType);
                    return _userType;
                }
            }
            else
                return null;
        }


        [HttpPost]
        [Route("insert")]
        public int Insert([FromBody] userType _userType)
        {
            if (ModelState.IsValid)
            {
                if (_userType == null)
                {
                    //userType ouserType = new userType();
                    return 0;
                }

                else
                {

                    var affectedRows = manageUsers.insertUsers(_userType);
                    return affectedRows;
                }
            }
            else
                return 0;
        }


        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] userType _userType)
        {
            if (manageUsers.getUsers(_userType) == null)
            {
                // update statement

            }
            return true;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return true;
        }
    }
}
