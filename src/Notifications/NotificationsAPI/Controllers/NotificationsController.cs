using Microsoft.AspNetCore.Mvc;
using NotificationsAPI.Infrastructure.Services;
using NotificationsAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationsAPI.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationFactoryService _notificationFactoryService;

        public NotificationsController(INotificationFactoryService notification)
        {
            _notificationFactoryService = notification;
        }

        [HttpPost]
        public async Task<IActionResult> Notify(NotificatonInputModel model)
        {
            var notification =  _notificationFactoryService.GetFacade(model.Type);

            await notification.SendAsync(model.Destination, model.Content);
          
            return Accepted();
        }
    }
}

