using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace PCIapi.Model
{
    public class ManageProfile : DBconnection
    {
        public ManageProfile(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<ManageProfileViewModel> getProfileDetails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT EmployeeID,Designation ,Department,JoinDate,EmailID,Status FROM MstUsers ";
                dbConnection.Open();
                return dbConnection.Query<ManageProfileViewModel>(sQuery);
            }
        }
    

    }

public class ManageProfileViewModel
    {
        public string EmployeeID { get; set; }
        public string Designation { get; set; }
        public string  Department { get; set; }
        public DateTime JoinDate { get; set; }
        public string EmailID { get; set; }
        public string Status { get; set; }
    }
}

