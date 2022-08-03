using System;
namespace NotificationsAPI.Models
{
    public class NotificatonInputModel
    {
        public string Destination { get; set; }

        public string Content { get; set; }

        public NotificationType Type { get; set; }
    }
}

