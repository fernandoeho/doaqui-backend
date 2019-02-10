using System;

namespace DoeAqui.Application.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public int Status { get; set; }
        public int Freight { get; set; }
        public string ImageUrl { get; set; }
        public Guid UserId { get; set; }
    }
}