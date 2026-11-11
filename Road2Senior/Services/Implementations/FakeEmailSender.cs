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

        public Task SendAsync(string to, string subject, string body)
        {

            _logger.LogWarning("[Testing Logging] Recipient: {To}, Subject: {Subject}, Email Sent To {To}",to,subject,to);

            return Task.CompletedTask;

        }
    }
}
