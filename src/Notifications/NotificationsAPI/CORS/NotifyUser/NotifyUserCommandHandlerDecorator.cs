using System;
using Newtonsoft.Json;
using NotificationsAPI.Infrastructure.Services;
using Serilog;

namespace NotificationsAPI.CORS.NotifyUser
{
    public class NotifyUserCommandHandlerDecorator : ICommandHandler<NotifyUserCommand, Task>
    {
        private readonly NotifyUserCommandHandler _handler;

        public NotifyUserCommandHandlerDecorator(NotifyUserCommandHandler handler)
        {
            _handler = handler;
        }

        public async Task Handler(NotifyUserCommand command)
        {
            Log.Information($"Command {command.GetType().Name} was handled with data {JsonConvert.SerializeObject(command)}");

            await _handler.Handler(command);
        }
    }
}

