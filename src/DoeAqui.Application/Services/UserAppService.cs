using System;
using AutoMapper;
using DoeAqui.Application.Interfaces;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.AggregateModels.UserAggregate.Commands;
using DoeAqui.Domain.AggregateModels.UserAggregate.Repository;
using DoeAqui.Domain.Core.Bus;

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

        public void Create(CreateUserViewModel createUserViewModel)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserViewModel);
            _bus.SendCommand(command);
        }

        public UserViewModel GetById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetById(id));
        }
    }
}