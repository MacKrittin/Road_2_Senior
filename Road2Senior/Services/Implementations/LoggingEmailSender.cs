using Road2Senior.Models;
using Road2Senior.Services.Interfaces;

namespace Road2Senior.Services.Implementations
{
    public class LoggingEmailSender : IEmailSender
    {
        private readonly ILogger<LoggingEmailSender> _logger;
        private readonly IEmailSender _emailSender;
        public LoggingEmailSender(ILogger<LoggingEmailSender> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }
        public Task SendAsync(string to, string subject, string body)
        {
            try
            {
                _logger.LogInformation("[LoggingEmailSender - Sending Email] Recipient: {To}", to);
                _emailSender.SendAsync(to, subject, body);

                return Task.CompletedTask;
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError("LoggingEmailSender ArgumentNullException Error {errorMsg}", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("LoggingEmailSender Exception Error {errorMsg}", ex);
            }


            return Task.CompletedTask;
        }
    }
}
