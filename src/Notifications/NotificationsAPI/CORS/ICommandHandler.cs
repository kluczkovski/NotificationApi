using System;
namespace NotificationsAPI.CORS
{
    public interface ICommandHandler<Command, Response> where Command : ICommand
    {
        Response Handler(Command command);
    }
}

