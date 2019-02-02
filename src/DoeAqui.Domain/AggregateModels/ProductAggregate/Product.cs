using System;
using System.Collections.Generic;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Enums;
using DoeAqui.Domain.Core.Models;
using FluentValidation;

namespace DoeAqui.Domain.AggregateModels.ProductAggregate
{
    public class Product : Entity<Product>
    {
        public Product(Guid id, string title, string description, int quantity, string size, EStatus status, EFreight freight, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Quantity = quantity;
            Size = size;
            Status = status;
            Freight = freight;
            ImageUrl = imageUrl;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public string Size { get; private set; }
        public EStatus Status { get; private set; }
        public EFreight Freight { get; private set; }
        public string ImageUrl { get; private set; }

        public override bool IsValid()
        {
            Validate();

            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            RuleFor(p => p.Title)
               .NotEmpty().WithMessage("Título é obrigatório")
               .Length(2, 100).WithMessage("Título precisa ter entre 2 e 255 caracteres");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Descrição é obrigatório");

            RuleFor(p => Quantity)
                .NotEmpty().WithMessage("Quantidade é obrigatório");

            RuleFor(p => p.Size)
                .NotEmpty().WithMessage("Tamanho é obrigatóro")
                .MaximumLength(25).WithMessage("Tamanho precisa ter no máximo 8 caracteres");

            RuleFor(p => p.Status)
                .IsInEnum();

            RuleFor(p => p.Freight)
                .IsInEnum();

            RuleFor(p => p.ImageUrl)
                .NotEmpty().WithMessage("Imagem é obrigatóro");

            ValidationResult = Validate(this);
        }
    }
}