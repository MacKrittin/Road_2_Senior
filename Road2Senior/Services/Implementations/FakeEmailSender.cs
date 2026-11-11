using Road2Senior.Services.Interfaces;

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
            _logger.LogInformation("Starting email sending..." 
                + Environment.NewLine + "Recipient: {To}", to 
                + Environment.NewLine + "Subject: {Subject}", subject 
                + Environment.NewLine + "Email sent successfully to {To}", to);

        }
    }
}
