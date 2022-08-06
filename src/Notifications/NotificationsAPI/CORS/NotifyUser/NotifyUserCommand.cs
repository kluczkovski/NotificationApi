using System;
using NotificationsAPI.Models;

namespace NotificationsAPI.CORS
{
    public class NotifyUserCommand : ICommand
    {
        public string Destination { get; set; }

        public string Content { get; set; }

        public NotificationType NotificationType { get; set; }

    }
}

