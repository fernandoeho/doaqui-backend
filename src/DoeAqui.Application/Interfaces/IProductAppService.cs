using System;
using System.Collections.Generic;
using DoeAqui.Application.ViewModels.Product;
using DoeAqui.Helper.Enums;

namespace DoeAqui.Application.Interfaces
{
    public interface IProductAppService
    {
        ProductViewModel GetById(Guid id);
        IEnumerable<EnumValue> GetFreights();
        IEnumerable<EnumValue> GetStatus();
        void Create(CreateProductViewModel vm);
    }
}