using System;
using NotificationsAPI.Models;

namespace NotificationsAPI.Infrastructure.Services
{
    public interface INotificationFactoryService
    {
        INotification GetFacade(NotificationType type);
    }
}

