using System;
using AutoMapper;
using DoeAqui.Application.Interfaces;
using DoeAqui.Application.ViewModels.Product;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Commands;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Repository;
using DoeAqui.Domain.Core.Bus;

namespace DoeAqui.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public ProductAppService(IProductRepository productRepository, IBus bus, IMapper mapper)
        {
            _mapper = mapper;
            _bus = bus;
            _productRepository = productRepository;
        }

        public void Create(CreateProductViewModel vm)
        {
            var command = _mapper.Map<CreateProductCommand>(vm);
            _bus.SendCommand(command);
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }
    }
}