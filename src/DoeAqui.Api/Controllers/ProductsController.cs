using System;
using DoeAqui.Application.Interfaces;
using DoeAqui.Application.ViewModels.Product;
using DoeAqui.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoeAqui.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IDomainNotificationHandler<DomainNotification> notifications, IProductAppService productAppService)
            : base(notifications)
        {
            _productAppService = productAppService;
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Response(_productAppService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateProductViewModel vm)
        {
            _productAppService.Create(vm);

            return Response();
        }
    }
}