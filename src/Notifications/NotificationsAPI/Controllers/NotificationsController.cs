using Microsoft.AspNetCore.Mvc;
using NotificationsAPI.CORS;
using NotificationsAPI.Infrastructure.Services;
using NotificationsAPI.Mediator;
using NotificationsAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationsAPI.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Notify(NotifyUserCommand command)
        {
            await _mediator.Send(command);
 
            return Accepted();
        }
    }
}

