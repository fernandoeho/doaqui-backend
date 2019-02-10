using System;
using DoeAqui.Application.ViewModels.User;

namespace DoeAqui.Application.ViewModels.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public int Status { get; set; }
        public int Freight { get; set; }
        public string ImageUrl { get; set; }
        public UserViewModel User { get; set; }
    }
}