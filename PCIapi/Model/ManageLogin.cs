using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
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
        public string UpdateNewPassword(string emailID, string password,string oldpassword)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE MstLogintbl SET Password = @_strPassword,IsReset = 0 where EmailID = @_strEmailID AND Password =@_strOldPassword";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strEmailID = emailID, _strPassword = password,_strOldPassword = oldpassword });
                if (affectedRows > 0)
                    return "New Password updated succesfully";
                else
                    return "Invalid old password";
                
            }

        }


        public string getUserByEmailId(string emailID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT UserName from MstLogintbl where EmailId=@_StrEmailId";
                dbConnection.Open();
                return dbConnection.Query<string>(sQuery, new { _StrEmailId = emailID }).FirstOrDefault();
            }

        }

        public string getUserUnblockedByEmailID(string emailID)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE MstLogintbl set IsBlocked = 1 where EmailID = @_strEmailID";
                dbConnection.Open();
                var affectedRows = dbConnection.Execute(sQuery, new { _strEmailID = emailID });
                if (affectedRows > 0)
                    return "Unblocking successfull";
                else
                    return " Unblocking unsuccessfull ";

            }

        }
        public string UpdateSendPassword(string emailID)
        {
            var password = CreatePassword(8);
            var roweffected = UpdateLoginPassword(emailID, password);
            if(roweffected >0)
            {
                MailMessage mailMessage = new MailMessage(_configuration["Mail:EmailID"], emailID);
                mailMessage.Subject = "Reset Password";
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
                   "<p style=\"text-align:left\">Hi " + getUserByEmailId(emailID) + ", <br><br> We received a request to reset the password for your account for this email address. To initiate the password reset process for your account, click the link below.\r\n </p>" +
                   "<p>\r\n <a target=\"_blank\" style=\"text-decoration:none; background-color: black; border: black 1px solid; color: #fff; padding:10px 10px; display:block;\" href=\"https://google.com\">\r\n<strong>Reset Password</strong></a>\r\n</p>" +
                   "  <p style=\"text-align:left\">Your requested 8 digit password is : " + password + "" +
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
        public string CreateToken(UserModel users)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, users.UserName));
            claims.Add(new Claim(ClaimTypes.Email, users.EmailId));





            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                 _configuration["jwt:Issuer"],
                _configuration["jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return (new JwtSecurityTokenHandler().WriteToken(token));
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
                var result = getUsers(Username,password);
                return CreateToken(result);
            }
           
        }
        public UserModel getUsers( string UserName,  string Password)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT  EmailID, UserName,IsReset,IsBlocked from MstLogintbl Where UserName=@_strUsername AND Password=@_strPassword";
                dbConnection.Open();
                return dbConnection.Query<UserModel>(sQuery, new { _strUsername= UserName, _strPassword = Password }).FirstOrDefault();
            }
        }

        public IEnumerable<loginTbl> getLoginDetails(string UserName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT IsReset FROM MstLogintbl WHERE UserName=@_LogintblUserName OR EmailID = @_LogintblUserName";
                dbConnection.Open();
                return dbConnection.Query<loginTbl>(sQuery, new { _loginTblUserName = UserName });
            }
        }


       
    }
    public class loginTbl
    {
        public bool IsReset { get; set; }
    }

}

