using DoeAqui.Application.Interfaces;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace DoeAqui.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IDomainNotificationHandler<DomainNotification> notifications, IUserAppService userAppService)
            : base(notifications)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateUserViewModel vm)
        {
            _userAppService.Create(vm);

            return Response();
        }
    }
}