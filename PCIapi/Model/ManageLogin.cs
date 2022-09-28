using Dapper;
using Microsoft.Extensions.Configuration;
using System;
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

       





    }
}
