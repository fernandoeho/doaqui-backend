using System.Linq;
using DoeAqui.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace DoeAqui.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        protected new IActionResult Response(object result = null)
        {
            if (IsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected bool IsValid()
        {
            return (!_notifications.HasNotifications());
        }
    }
}