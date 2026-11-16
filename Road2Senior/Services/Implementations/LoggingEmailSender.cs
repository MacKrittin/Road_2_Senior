using Road2Senior.Models;
using Road2Senior.Services.Interfaces;
using System.Diagnostics;

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
        public async Task SendAsync(string to, string subject, string body)
        {
            var stopWatch = Stopwatch.StartNew();
            try
            {
                _logger.LogInformation("[LoggingEmailSender - Sending Email] Recipient: {To}", to);

                await _emailSender.SendAsync(to, subject, body);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LoggingEmailSender Exception Error");
                throw;
            }
            finally { 
                _logger.LogInformation("LoggingEmailSender Time : {time} ms",stopWatch.ElapsedMilliseconds);
            }


        }
    }
}
