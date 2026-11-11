using Microsoft.AspNetCore.Identity;
using Road2Senior.Services.Interfaces;
using System.Net.Mail;

namespace Road2Senior.Services.Implementations
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _config; // di

        public SmtpEmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            using var client = new SmtpClient(_config["Smtp:Host"], int.Parse(_config["Smtp:Port"]!));
            var message = new MailMessage("noreply@company.com", to, subject, body);
            await client.SendMailAsync(message);
        }
    }
}
