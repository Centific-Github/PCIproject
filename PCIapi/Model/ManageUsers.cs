﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;

namespace PCIapi.Model
{
    /// <summary>
    /// Following code has been written by: rajib Basu
    /// date: 19-Sept-2022
    /// </summary>
    public class ManageUsers : DBconnection
    {
        private IConfiguration _configuration;

        public ManageUsers(IConfiguration configuration) : base(configuration)
        {

            
                _configuration = configuration;
            


        }
        public IEnumerable<userType> getUsers()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT LoginID, EmailID, Password, UserName,EmployeeID,IsAdmin,Roles,FirstName,LastName,IsBlocked from MstLogintbl";
                dbConnection.Open();
                return dbConnection.Query<userType>(sQuery);
            }
        }
        public userType getUsers(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT LoginID, EmailID, Password, UserName,EmployeeID,IsAdmin,Roles,FirstName,LastName,IsBlocked from MstLogintbl where LoginID=@_LoginId";
                dbConnection.Open();
                return dbConnection.Query<userType>(sQuery, new { _LoginId = id }).FirstOrDefault();
            }
        }
        public userType getUsers(userType _userType)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT LoginID, EmailID, UserName,EmployeeID ,IsAdmin ,Roles from MstLogintbl Where EmailID=@_strEmailID AND Password=@_strPassword";
                dbConnection.Open();
                return dbConnection.Query<userType>(sQuery, new { _strEmailID = _userType.EmailID, _strPassword = _userType.Password }).FirstOrDefault();
            }
        }
        public string insertUsers(userTypeDTO _userTypeDTO)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT into MstLogintbl ( EmailID, UserName,EmployeeID,Roles,Password,FirstName,LastName) values(@_strEmailID,@_strUserName,@_strPassword,@_strFirsttName,@_strLastName,@_strEmployeeID,@_strRoles)";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strEmailID = _userTypeDTO.EmailID, _strUserName = _userTypeDTO.UserName, _strEmployeeID= _userTypeDTO.EmployeeID, _strRoles = _userTypeDTO.Roles, _strPassword = _userTypeDTO.Password, _strFirsttName = _userTypeDTO.FirstName, _strLastName = _userTypeDTO.LastName });
                 if (affectedRows > 0)
                {
                    WelcomeMail(_userTypeDTO);
                    return " User inserted successfully";

                }
                else
                {
                    return "User notinserted ";
                }



            
            }

        }
        public void WelcomeMail(userTypeDTO _userTypeDTO)
        {

            MailMessage mailMessage = new MailMessage(_configuration["Mail:EmailID"], _userTypeDTO.EmailID);
            mailMessage.Subject = "Welcome Mail";
            mailMessage.IsBodyHtml = true;
            string emailbody = "<html>" +
               "<head>" +
               "<title>HTML email template</title>" +
               "<meta name=\"viewport\" content=\"width = 375, initial-scale = -1\">" +
               "</head>" +
               " <body style=\"background-color: #ffffff; font-size: 16px;\">" +
               "<center>" +
               "      <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"height:100%; width:600px;\">" +
               "<tr>" +
               " <td align=\"center\" bgcolor=\"#ffffff\" style=\"padding:30px\">" +
               "<p style=\"text-align:left\">Hi " + _userTypeDTO.EmailID + ", <br><br> \r\n </p>" +
               "<p>\r\n <a target=\"_blank\" style=\"text-decoration:none; background-color: black; border: black 1px solid; color: #fff; padding:10px 10px; display:block;\" href=\"http://localhost:4200/Login\">\r\n<strong>Welcome TO PCI</strong></a>\r\n</p>" +

               "<p style=\"text-align:left\">\r\nSincerely,<br>The Website Team\r\n</p>" +
               "</td>\r\n</tr>\r\n        </tbody>\r\n      </table>\r\n    </center>\r\n  </body>\r\n</html>";
            mailMessage.Body = emailbody;
            var smpt = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(_configuration["Mail:EmailID"], _configuration["Mail:Password"]),
                EnableSsl = true
            };
            smpt.Send(mailMessage);

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
        public string getcheckingEmployeeID(string employeeid)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select 1 from  MstLogintbl  where EmployeeID = @_strEmployeeID";
                dbConnection.Open();
                var result = dbConnection.Query<string>(sQuery, new { _strEmployeeID = employeeid });
                if (result.Count() > 0)
                {
                    return "EmployeeID exist";
                }
                else
                {
                    return "EmployeeID doesnot exist";
                }
            }
        }
        public string getcheckingIsAdmin(string username)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"select 1 from MstLogintbl where Username=@_strUserName or EmployeeID=@_strUserName and IsAdmin=1";
                dbConnection.Open();
                var result = dbConnection.Query<string>(sQuery, new { _strUserName = username });
                if (result.Count() > 0 || result.Count() < 0)
                {
                    return "IsAdmin exist";
                }
                else
                {
                    return "IsAdmin doesnot exist";
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
            public string EmployeeID { get; set; }
            public bool IsAdmin { get; set; }
            public string Roles { get; set; }



        }
        public class userTypeDTO
        {

            public string EmailID { get; set; }
            public string Password { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmployeeID { get; set; }
           
            public string Roles { get; set; }

        }

    }
}
