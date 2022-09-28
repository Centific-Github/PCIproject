using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PCIapi.Model;
using System.Net.Mail;

namespace PCIapi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ManageLoginController : Controller
    {
        private IConfiguration _configuration;

        private readonly ManageLogin manageLogin;
        public ManageLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            manageLogin = new ManageLogin(_configuration);
        }


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
        [Route("reset")]
        public string reset([FromBody] UserReset userReset)
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
    }
}


