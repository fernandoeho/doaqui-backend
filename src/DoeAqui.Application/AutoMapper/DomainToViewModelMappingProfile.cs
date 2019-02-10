using AutoMapper;
using DoeAqui.Application.ViewModels.Product;
using DoeAqui.Application.ViewModels.User;
using DoeAqui.Domain.AggregateModels.ProductAggregate;
using DoeAqui.Domain.AggregateModels.UserAggregate;

namespace DoeAqui.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();

            CreateMap<Product, ProductViewModel>();
        }
    }
}