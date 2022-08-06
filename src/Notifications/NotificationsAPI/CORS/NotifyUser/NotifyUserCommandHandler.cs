using System;
using NotificationsAPI.Infrastructure.Services;

namespace NotificationsAPI.CORS.NotifyUser
{
    public class NotifyUserCommandHandler : ICommandHandler<NotifyUserCommand, Task>
    {
        private readonly INotificationFactoryService _notificationFactoryService;

        public NotifyUserCommandHandler(INotificationFactoryService notificationFactoryService)
        {
            _notificationFactoryService = notificationFactoryService;
        }

        public async Task Handler(NotifyUserCommand command)
        {
            var notificationService = _notificationFactoryService.GetFacade(command.NotificationType);

            await notificationService.SendAsync(command.Destination, command.Content);
        }
    }
}

