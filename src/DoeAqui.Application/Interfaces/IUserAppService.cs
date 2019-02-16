using System;
using System.Collections.Generic;
using DoeAqui.Application.ViewModels.User;

namespace DoeAqui.Application.Interfaces
{
    public interface IUserAppService
    {
        object Authenticate(LoginViewModel vm);
        UserViewModel GetById(Guid id);
        IEnumerable<UserViewModel> GetAll();
        void Create(CreateUserViewModel vm);
        void Update(UpdateUserViewModel vm);
    }
}