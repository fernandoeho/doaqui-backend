using System;
using DoeAqui.Application.ViewModels.Product;

namespace DoeAqui.Application.Interfaces
{
    public interface IProductAppService
    {
        ProductViewModel GetById(Guid id);
        void Create(CreateProductViewModel vm);
    }
}