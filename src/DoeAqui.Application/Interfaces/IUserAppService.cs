using DoeAqui.Application.ViewModels.User;

namespace DoeAqui.Application.Interfaces
{
    public interface IUserAppService
    {
        void Create(CreateUserViewModel createUserViewModel);
    }
}