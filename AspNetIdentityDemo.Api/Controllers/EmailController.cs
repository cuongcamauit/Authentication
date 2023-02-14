using AspNetIdentityDemo.Api.Models;
using AspNetIdentityDemo.Api.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace AspNetIdentityDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService _mailServer;
        private readonly IConfiguration _configuration;

        
        public EmailController(IMailService mailServer,IConfiguration configuration)
        {
            _mailServer = mailServer;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(MailRequest mailRequest)
        {
           
            await _mailServer.SendEmailAsync(mailRequest.ToEmail,
                                             mailRequest.Subject,
                                             mailRequest.Body);

            return Ok();
        }
        
    }
}
