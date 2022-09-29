using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace PCIapi.Model
{
    public class ManageLogin : DBconnection
    {
        private IConfiguration _configuration;
        public ManageLogin(IConfiguration configuration) : base(configuration)
        {
        _configuration = configuration;
        }
        

        public string CreatePassword(int length)
        {

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        public int UpdateLoginPassword(string emailID,string password)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE MstLogintbl SET Password = @_strPassword where EmailID = @_strEmailID";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strEmailID = emailID, _strPassword = password });
                return affectedRows;
            }
            

           

        }
        public string UpdateSendPassword(string emailID)
        {
            var password = CreatePassword(8);
            var roweffected = UpdateLoginPassword(emailID, password);
            if(roweffected >0)
            {
                MailMessage mailMessage = new MailMessage(_configuration["Mail:EmailID"], "rahul.reddy@pacteraedge.com");
                mailMessage.Subject = "Reset Password";
                mailMessage.Body = "Your Random 8 Digit Password Is :"+password+"";
                var smpt = new System.Net.Mail.SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential(_configuration["Mail:EmailID"], _configuration["Mail:Password"]),
                    EnableSsl = true
                };
                smpt.Send(mailMessage);
                return "Password Reset Sucefull";

            }
            else
            {
                return "Invalid EmailID"
 ;           }
        }
        public int CheckingUser(string Username,string password)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var p = new DynamicParameters();
                p.Add("Username",Username);
                p.Add("Password", password);
                p.Add("LoginStatus", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dbConnection.Query<int>("IsValidUser", p, commandType: CommandType.StoredProcedure);
                int Status = p.Get<int>("LoginStatus");
                return Status;
            }
        }
        public string IsUserValid(string Username,string password)
        {
            var IsValid = CheckingUser(Username, password);
           if(IsValid == 2)
            {
                return "Invalid Username";
            }
           else if(IsValid == 3)
            {
                return "Invali Password";
            }
           else if(IsValid == 4)
            {
                return "User Is Blocked";
            }
            else
            {
                return "Valid";
            }
        }





    }
}
