using Microsoft.Extensions.Logging;
namespace DutchTreat.Services
{
    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> _logger;

        public  NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }

        public void SendMessage(string to, string email, string subject, string body) 
        { 
            // log the message
            _logger.LogInformation($"To: {to} at email: {email} with Subject: {subject} and message: {body}");
        }
    }
}