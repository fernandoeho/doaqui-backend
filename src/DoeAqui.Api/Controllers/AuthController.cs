using DoeAqui.Api.Configurations;
using DoeAqui.Application.Interfaces;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DoeAqui.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IUserAppService _userAppService;
        private readonly IConfiguration _configuration;

        public AuthController(IDomainNotificationHandler<DomainNotification> notifications, IUserAppService userAppService, IConfiguration configuration)
            : base(notifications)
        {
            _configuration = configuration;
            _userAppService = userAppService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]LoginViewModel vm)
        {
            var userVM = _userAppService.Authenticate(vm);

            if (!IsValid())
                return Response();

            var jwtResponse = JwtExtension.GetToken(userVM, _configuration);

            return Response(jwtResponse);
        }
    }
}