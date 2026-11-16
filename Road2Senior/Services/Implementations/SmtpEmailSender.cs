
using Road2Senior.Services.Interfaces;
using System.Net.Mail;

namespace Road2Senior.Services.Implementations
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _config; // di
        private readonly ILogger<SmtpEmailSender> _logger;

        public SmtpEmailSender(IConfiguration config, ILogger<SmtpEmailSender> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            using var client = new SmtpClient(_config["Smtp:Host"], int.Parse(_config["Smtp:Port"]!));
            var message = new MailMessage("noreply@company.com", to, subject, body);
            _logger.LogInformation("[Sending Email] Recipient: {To}, Subject: {Subject}, Body : {Body}", to, subject, body);
            await client.SendMailAsync(message);
        }
    }
}
