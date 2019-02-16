using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DoeAqui.Application.Interfaces;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.AggregateModels.UserAggregate.Commands;
using DoeAqui.Domain.AggregateModels.UserAggregate.Repository;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Notifications;
using DoeAqui.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DoeAqui.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserAppService(IUserRepository userRepository, IBus bus, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _mapper = mapper;
            _bus = bus;
            _userRepository = userRepository;
        }

        public object Authenticate(LoginViewModel vm)
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

            var userVM = _mapper.Map<UserViewModel>(user);

            var jwt = GetToken(userVM);

            return jwt;
        }

        public void Create(CreateUserViewModel vm)
        {
            var command = _mapper.Map<CreateUserCommand>(vm);
            _bus.SendCommand(command);
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAll());
        }

        public UserViewModel GetById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetById(id));
        }

        public void Update(UpdateUserViewModel vm)
        {
            var command = _mapper.Map<UpdateUserCommand>(vm);
            _bus.SendCommand(command);
        }

        private object GetToken(UserViewModel vm)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt:Key").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, vm.Id.ToString()),
                    new Claim(ClaimTypes.Name, vm.Name),
                    new Claim(ClaimTypes.Email, vm.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            var response = new
            {
                access_token = tokenString
            };

            return response;
        }
    }
}