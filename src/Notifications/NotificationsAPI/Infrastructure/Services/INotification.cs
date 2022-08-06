using System;
namespace NotificationsAPI.Infrastructure.Services
{
    public interface INotification
    {
        Task SendAsync(string destination, string content);
    }
}

