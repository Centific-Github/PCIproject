using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PCIapi.Model
{
    /// <summary>
    /// Following code has been written by: rajib Basu
    /// date: 19-Sept-2022
    /// </summary>
    public class ManageUsers : DBconnection
    {
        public ManageUsers(IConfiguration configuration) : base(configuration)
        {



        }
        public IEnumerable<userType> getUsers()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT LoginID, EmailID, Password, UserName from MstLogintbl";
                dbConnection.Open();
                return dbConnection.Query<userType>(sQuery);
            }
        }
        public userType getUsers(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT LoginID, EmailID, Password, UserName,FirstName,LastName,IsBlocked from MstLogintbl where LoginID=@_LoginId";
                dbConnection.Open();
                return dbConnection.Query<userType>(sQuery, new { _LoginId = id }).FirstOrDefault();
            }
        }
        public userType getUsers(userType _userType)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT LoginID, EmailID, UserName from MstLogintbl Where EmailID=@_strEmailID AND Password=@_strPassword";
                dbConnection.Open();
                return dbConnection.Query<userType>(sQuery, new { _strEmailID = _userType.EmailID, _strPassword = _userType.Password }).FirstOrDefault();
            }
        }
        public int insertUsers(userType _userType)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT into MstLogintbl ( EmailID, UserName,Password,FirstName,LastName) values(@_strEmailID,@_strUserName,@_strPassword,@_strFirsttName,@_strLastName)";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strEmailID = _userType.EmailID, _strUserName = _userType.UserName, _strPassword = _userType.Password, _strFirsttName = _userType.FirstName, _strLastName = _userType.LastName });
                return affectedRows;
            }
        }
        public string getcheckingEmailID(string emailID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select 1 from  MstLogintbl  where EmailID = @_strEmailID";
                dbConnection.Open();
                var result = dbConnection.Query<int>(sQuery, new { _strEmailID = emailID });
                if (result.Count() > 0)
                {
                    return "EmailId exist";
                }
                else
                {
                    return "EmailId doesnot exist";
                }




            }

        }
        public string getcheckingUserName(string username)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select 1 from  MstLogintbl  where UserName = @_strUserName";
                dbConnection.Open();
                var result = dbConnection.Query<string>(sQuery, new { _strUserName = username });
                if (result.Count() > 0)
                {
                    return "UserName exist";
                }
                else
                {
                    return "UserName doesnot exist";
                }

            }
        }

        public class userType
        {

            public string EmailID { get; set; }
            public string Password { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int IsBlocked { get; set; }
        }

    }
}
