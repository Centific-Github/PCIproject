using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
using System.Collections.Generic;
using System.Net.Mail;

namespace PCIapi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ManageLoginController : Controller
    {
        //jwt
        //private IUserRepository _userRepository;
        //private ItokenHandler _tokenHandler;
        //public AuthController(IUserRepository userRepository, ItokenHandler itokenHandler)
        //{
        //    _userRepository = userRepository;
        //    _tokenHandler = itokenHandler;
        //}
        private IConfiguration _configuration;
        private readonly ManageLogin manageLogin;
        public ManageLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageLogin = new ManageLogin(_configuration);
        }

        [Authorize]
        [HttpGet]
        [Route("Send")]
        public int sentmail()
        {
            MailMessage mailMessage = new MailMessage(_configuration["Mail:EmailID"], "hemasri.duvvuru@pacteraedge.com");
            mailMessage.Subject = "Test Subject";
            mailMessage.Body = "Test";
            var smpt = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(_configuration["Mail:EmailID"], _configuration["Mail:Password"]),
                EnableSsl = true
            };



            smpt.Send(mailMessage);
            return 0;


        }
        [HttpPost]
        [Route("Reset")]
        public string Reset([FromBody] UserEmailID userReset)
        {
            if (ModelState.IsValid)
            {
                if (userReset == null)
                {
                    return "Please pass the EmailID";
                }
                else
                {
                    return manageLogin.UpdateSendPassword(userReset.EmailID);
                }
            }
            else
                return "Invalid Model";
        }
      
        [HttpPost]
        [Route("Login")]
        public string Login([FromBody] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                return manageLogin.IsUserValid(userLogin.Username, userLogin.Password);
            }
            else
            {
                return "Invalid Model";
            }

        }
      
        [HttpPut]
        [Route("NewPassword")]
        public string NewPassword([FromBody] UpdateResetPassword resetPassword)
        {
            if (ModelState.IsValid)
            {
                if (resetPassword == null)
                {
                    return "Please enter the Password";
                }
                else
                {
                    return manageLogin.UpdateNewPassword(resetPassword.EmailID, resetPassword.Password, resetPassword.OldPassword);
                   
                }
            }
            else
                return "Invalid Model";
        }
        [HttpPut]
        [Route("IsBlocked")]
        public string IsBlocked([FromBody] UserEmailID userUnblocked)
        {
            if (ModelState.IsValid)
            {
                if (userUnblocked == null)
                {
                    return "Blocking successfull";
                }
                else
                {
                    return manageLogin.getUserIsblockedByEmailID(userUnblocked.EmailID);
                }
            }
            else
                return "Blocked unsuccessful";
        }
        [HttpPut]
        [Route("UnBlocked")]
        public string UnBlocked([FromBody] UserEmailID userUnblocked)
        {
            if (ModelState.IsValid)
            {
                if (userUnblocked == null)
                {
                    return "Unblocking successfull";
                }
                else
                {
                    return manageLogin.getUserUnblockedByEmailID(userUnblocked.EmailID);
                }
            }
            else
                return "Unblocked unsuccessful";
        }




        [HttpGet]
        [Route("GetIsReset")]
        public IEnumerable<loginTbl> GetIsReset(string UserName)
        {
            return manageLogin.getLoginDetails(UserName);
        }
    }

   
}



