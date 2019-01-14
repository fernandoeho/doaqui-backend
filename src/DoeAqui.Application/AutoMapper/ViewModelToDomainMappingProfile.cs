using AutoMapper;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.AggregateModels.UserAggregate.Commands;

namespace DoeAqui.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateUserViewModel, CreateUserCommand>()
                .ConstructUsing(c => new CreateUserCommand(c.Name, c.Email, c.Password, c.Phone));
        }
    }
}