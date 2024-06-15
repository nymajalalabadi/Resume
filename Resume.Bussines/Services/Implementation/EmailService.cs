using Microsoft.Extensions.Configuration;
using Resume.Bussines.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bussines.Services.Implementation
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmail(string to, string subject, string body)
        {

            var fromEmail = _configuration["Settings:EmailSmtp:Sender"];
            string password = _configuration["Settings:EmailSmtp:Password"];


            try
            {
                var mail = new MailMessage();

                var smtpServer = new SmtpClient(_configuration["Settings:EmailSmtp:Host"]);

                mail.From = new MailAddress(fromEmail, "نیما جلال ابادی");

                mail.To.Add(to);

                mail.Subject = subject;

                mail.Body = body;

                mail.IsBodyHtml = true;

                smtpServer.Port = Convert.ToInt32(_configuration["Settings:EmailSmtp:Port"]); ;

                smtpServer.Credentials = new NetworkCredential(fromEmail, password);

                smtpServer.EnableSsl = Convert.ToBoolean(_configuration["Settings:EmailSmtp:EnableSSL"]);

                smtpServer.Send(mail);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
