using System;
using DoeAqui.Domain.Core.Models;
using FluentValidation;

namespace DoeAqui.Domain.AggregateModels.UserAggregate
{
    public class User : Entity<User>
    {
        public User(Guid id, string name, string email, string password, string passwordSalt, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            PasswordSalt = passwordSalt;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PasswordSalt { get; private set; }
        public string Phone { get; private set; }

        public void Update(string name, string email, string password, string passwordSalt, string phone)
        {
            Name = name;
            Email = email;
            Password = password;
            PasswordSalt = passwordSalt;
            Phone = phone;
        }

        public override bool IsValid()
        {
            Validate();

            return ValidationResult.IsValid;
        }

        private void Validate()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(2, 255).WithMessage("Nome precisa ter entre 2 e 255 caracteres");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email é obrigatório")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Senha é obrigatório")
                .MinimumLength(8).WithMessage("Senha precisa ter no mínimo 8 caracteres");

            RuleFor(u => u.PasswordSalt)
                .NotEmpty().WithMessage("Senha-chave é obrigatório");

            RuleFor(u => u.Phone)
                .NotEmpty().WithMessage("Telefone é obrigatório");

            ValidationResult = Validate(this);
        }
    }
}