using System;
using DoeAqui.Application.ViewModels.User;

namespace DoeAqui.Application.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public string Size { get; private set; }
        public int Status { get; private set; }
        public int Freight { get; private set; }
        public string ImageUrl { get; private set; }
        public UserViewModel User { get; private set; }
    }
}