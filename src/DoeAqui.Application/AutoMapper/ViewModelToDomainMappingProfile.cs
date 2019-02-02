using AutoMapper;
using DoeAqui.Application.ViewModels.Product;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Commands;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Enums;
using DoeAqui.Domain.AggregateModels.UserAggregate.Commands;

namespace DoeAqui.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateUserViewModel, CreateUserCommand>()
                .ConstructUsing(c => new CreateUserCommand(c.Name, c.Email, c.Password, c.Phone));

            CreateMap<UpdateUserViewModel, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(c.Id, c.Name, c.Email, c.Password, c.Phone));

            CreateMap<CreateProductViewModel, CreateProductCommand>()
                .ConstructUsing(c => new CreateProductCommand(c.Title, c.Description, c.Quantity, c.Size, (EStatus)c.Status, (EFreight)c.Freight, c.ImageUrl, c.UserId));
        }
    }
}