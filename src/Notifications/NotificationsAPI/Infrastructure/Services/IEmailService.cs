using System;
namespace NotificationsAPI.Infrastructure.Services
{
    public interface IEmailService
    {
        Task SendAsync(string destination, string content);
    }
}

