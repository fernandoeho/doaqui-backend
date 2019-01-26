using System;
using DoeAqui.Application.ViewModels.User;

namespace DoeAqui.Application.Interfaces
{
    public interface IUserAppService
    {
        UserViewModel Authenticate(LoginViewModel vm);
        UserViewModel GetById(Guid id);
        void Create(CreateUserViewModel vm);
    }
}