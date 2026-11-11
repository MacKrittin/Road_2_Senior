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

            _logger.LogWarning("[this message is for testing the mail is not sending to anyone] Recipient: {To}, Subject: {Subject}, Body : {Body}",to,subject,body);

            return Task.CompletedTask;

        }
    }
}
