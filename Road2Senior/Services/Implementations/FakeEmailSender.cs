
using Road2Senior.Models;
using Road2Senior.Services.Interfaces;

namespace Road2Senior.Services.Implementations
{
    public class FakeEmailSender : IEmailSender
    {
        private readonly ILogger<FakeEmailSender> _logger;
        private readonly OperationTracker _operationTracker;

        public FakeEmailSender(ILogger<FakeEmailSender> logger, OperationTracker operationTracker)
        {
            _logger = logger;
            _operationTracker = operationTracker;
        }

        public Task SendAsync(string to, string subject, string body)
        {
            var operationTrackerMsg = _operationTracker.Id.ToString();
            _logger.LogInformation("[FAKE EMAIL GUID] : {1}", operationTrackerMsg);
            _logger.LogWarning("[FAKE EMAIL - NOT SEND] Recipient: {To}, Subject: {Subject}, Body : {Body}",to,subject,body);

            return Task.CompletedTask;

        }
    }
}
