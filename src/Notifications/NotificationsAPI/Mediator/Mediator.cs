using System;
using NotificationsAPI.CORS;

namespace NotificationsAPI.Mediator
{
    public class Mediator : IMediator
    {
        private readonly ICommandHandler<NotifyUserCommand, Task> _notifyUserHandler;

        public Mediator(ICommandHandler<NotifyUserCommand, Task> commandHandler)
        {
            _notifyUserHandler = commandHandler;
        }

        public async Task<object> Send(ICommand command)
        {
            if (command is NotifyUserCommand)
            {
                 await _notifyUserHandler.Handler((NotifyUserCommand)command);
            }

            return Task.CompletedTask;
        }
    }
}

