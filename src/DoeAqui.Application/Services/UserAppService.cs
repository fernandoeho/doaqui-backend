using System;
using AutoMapper;
using DoeAqui.Application.Interfaces;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.AggregateModels.UserAggregate.Commands;
using DoeAqui.Domain.AggregateModels.UserAggregate.Repository;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Notifications;
using DoeAqui.Helper;

namespace DoeAqui.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public UserAppService(IUserRepository userRepository, IBus bus, IMapper mapper)
        {
            _mapper = mapper;
            _bus = bus;
            _userRepository = userRepository;
        }

        public UserViewModel Authenticate(LoginViewModel vm)
        {
            var user = _userRepository.GetByEmail(vm.Email);

            if (user == null)
            {
                _bus.SendEvent(new DomainNotification("User", "Verifique email/senha e tente novamente"));
                return null;
            }

            string hashedPassword = Cryptography.Hash(vm.Password, user.PasswordSalt);

            if (hashedPassword != user.Password)
            {
                _bus.SendEvent(new DomainNotification("User", "Verifique email/senha e tente novamente"));
                return null;
            }

            return _mapper.Map<UserViewModel>(user);
        }

        public void Create(CreateUserViewModel vm)
        {
            var command = _mapper.Map<CreateUserCommand>(vm);
            _bus.SendCommand(command);
        }

        public UserViewModel GetById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetById(id));
        }
    }
}