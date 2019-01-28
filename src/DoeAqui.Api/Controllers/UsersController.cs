using System;
using DoeAqui.Application.Interfaces;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoeAqui.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IDomainNotificationHandler<DomainNotification> notifications, IUserAppService userAppService)
            : base(notifications)
        {
            _userAppService = userAppService;
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_userAppService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateUserViewModel vm)
        {
            _userAppService.Create(vm);

            return Response();
        }

        [HttpPut]
        public IActionResult Put([FromBody]UpdateUserViewModel vm)
        {
            _userAppService.Update(vm);

            return Response();
        }
    }
}