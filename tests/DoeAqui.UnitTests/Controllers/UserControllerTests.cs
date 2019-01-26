using System;
using DoeAqui.Api.Controllers;
using DoeAqui.Application.Interfaces;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DoeAqui.UnitTests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public void ReturnOKResult_When_UserIdValid()
        {
            var serviceMock = new Mock<IUserAppService>();
            serviceMock.Setup(m => m.GetById(Guid.Parse("eb349dee-893f-4fda-8535-6826445756b9")))
                .Returns(new UserViewModel
                {
                    Id = Guid.Parse("eb349dee-893f-4fda-8535-6826445756b9"),
                    Name = "James Bond",
                    Email = "james.bond@domain.com",
                    Phone = "123456789"
                });

            UsersController controller = new UsersController(new DomainNotificationHandler(), serviceMock.Object);

            var result = controller.GetById(Guid.Parse("eb349dee-893f-4fda-8535-6826445756b9"));

            Assert.IsType<OkObjectResult>(result);
        }
    }
}