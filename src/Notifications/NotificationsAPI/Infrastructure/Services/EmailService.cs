using System;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NotificationsAPI.Infrastructure.Services
{
    public class EmailService : INotification
    {
        private readonly ISendGridClient _sendGridClient;

        public EmailService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task SendAsync(string destination, string content)
        {
            var message = new SendGridMessage
            {
                From = new EmailAddress("kluczkovski@hotmail.com"),
                Subject = "You have a new message.",
                PlainTextContent = $"Here is your new message: {content}"
            };

            message.AddTo(destination);

            await _sendGridClient.SendEmailAsync(message);
        }
    }
}

