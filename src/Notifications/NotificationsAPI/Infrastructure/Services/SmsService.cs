using System;
using Serilog;


namespace NotificationsAPI.Infrastructure.Services
{
    public class SmsService : INotification
    {
        public SmsService()
        {
        }

        public Task SendAsync(string destination, string content)
        {
            Log.Information($"Sms was sent to {destination} with content {content}");

            return  Task.CompletedTask;
        }
    }
}

