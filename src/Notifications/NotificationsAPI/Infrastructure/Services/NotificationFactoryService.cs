using System;
using NotificationsAPI.Models;
using SendGrid;

namespace NotificationsAPI.Infrastructure.Services
{
    public class NotificationFactoryService : INotificationFactoryService
    {
        private readonly ISendGridClient _sendGridClient;

        public NotificationFactoryService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public INotification GetFacade(NotificationType type)
        {
            if (type == NotificationType.Email)
            {
                return new EmailService(_sendGridClient);
            }
            return new SmsService();
        }
    }
}

