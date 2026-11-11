using Road2Senior.Services.Interfaces;
using System.Net.Mail;

namespace Road2Senior.Services.Implementations
{
    public class FakeEmailSender : IEmailSender
    {
        private readonly ILogger<FakeEmailSender> _logger;

        public FakeEmailSender(ILogger<FakeEmailSender> logger)
        {
            _logger = logger;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            _logger.LogInformation("Starting email sending...");

            _logger.LogInformation("Recipient: {To}", to);
            _logger.LogInformation("Subject: {Subject}", subject);

            // จำลองระยะเวลาการส่ง Email
            await Task.Delay(1000);

            _logger.LogInformation("Email sent successfully to {To}", to);
        }
    }
}
