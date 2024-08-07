﻿using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

//OK, gmail działa - trzeba zrobić dla niego nowego maila i można podziałać póki co zapisuje te dane u siebie
//lokalnie, a potem po testach stwroze nowe konto
namespace LocalFarmer2.Server.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To == string.Empty ? _config.GetSection("EmailUsername").Value : request.To));
            email.Subject = $"LocalFarmer: {request.Subject}";
            email.Body = new TextPart(TextFormat.Html) 
            { 
                Text = 
                    $"{request.From}" +
                    $"<br /> <br />" +
                    $"{request.Body}" +
                    $" <br /> <br />" +
                    $"Send from application LocalFarmer"
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
