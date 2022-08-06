using System;
using NotificationsAPI.CORS;

namespace NotificationsAPI.Mediator
{
    public interface IMediator
    {
        Task<Object> Send(ICommand command);
    }
}

