using Domain.Helpers;
using Domain.Services.SignUp.DTOs;
using MailKit.Net.Smtp;
using Domain.Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;

namespace Domain.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;
        private readonly IConfiguration _config;
        public EmailService(IOptions<EmailSettings>options, IConfiguration config)
        {
            emailSettings = options.Value;
            _config = config;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var FromMail = _config.GetSection("MailSettings")["FromMail"];
                var DisplayName = _config.GetSection("MailSettings")["DisplayName"];
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(emailSettings.Email);
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(emailSettings.Host, emailSettings.Port, emailSettings.UseSSL ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto);
                smtp.Authenticate(emailSettings.Email, emailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
            

        }
    }
}
