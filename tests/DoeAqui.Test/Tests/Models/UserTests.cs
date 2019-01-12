using System;
using DoeAqui.Domain.AggregateModels.UserAggregate;
using Xunit;

namespace DoeAqui.Test.Tests.Models
{
    public class UserTests
    {
        [Fact]
        public void ReturnTrue_When_UserIsValid()
        {
            var user = new User(Guid.NewGuid(), "James Bond", "james.bond@mi6.com", "james123", "123456", "+44 3069 990585");

            Assert.True(user.IsValid());
        }

        [Fact]
        public void ReturnFalse_When_NameNotProvided()
        {
            var user = new User(Guid.NewGuid(), "", "james.bond@mi6.com", "james123", "123456", "+44 3069 990585");

            Assert.False(user.IsValid());
            Assert.Equal(2, user.ValidationResult.Errors.Count);
            Assert.Equal("Nome é obrigatório", user.ValidationResult.Errors[0].ErrorMessage);
            Assert.Equal("Nome precisa ter entre 2 e 255 caracteres", user.ValidationResult.Errors[1].ErrorMessage);
        }

        [Fact]
        public void ReturnFalse_When_EmailNotProvided()
        {
            var user = new User(Guid.NewGuid(), "James Bond", "", "james123", "123456", "+44 3069 990585");

            Assert.False(user.IsValid());
            Assert.Equal(2, user.ValidationResult.Errors.Count);
            Assert.Equal("Email é obrigatório", user.ValidationResult.Errors[0].ErrorMessage);
            Assert.Equal("Email inválido", user.ValidationResult.Errors[1].ErrorMessage);
        }

        [Fact]
        public void ReturnFalse_When_EmailFormatIsInvalid()
        {
            var user = new User(Guid.NewGuid(), "James Bond", "james.bond.com", "james123", "123456", "+44 3069 990585");

            Assert.False(user.IsValid());
            Assert.Equal(1, user.ValidationResult.Errors.Count);
            Assert.Equal("Email inválido", user.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact]
        public void ReturnFalse_When_PasswordNotProvided()
        {
            var user = new User(Guid.NewGuid(), "James Bond", "james.bond@mi6.com", "", "123456", "+44 3069 990585");

            Assert.False(user.IsValid());
            Assert.Equal(2, user.ValidationResult.Errors.Count);
            Assert.Equal("Senha é obrigatório", user.ValidationResult.Errors[0].ErrorMessage);
            Assert.Equal("Senha precisa ter no mínimo 8 caracteres", user.ValidationResult.Errors[1].ErrorMessage);
        }

        [Fact]
        public void ReturnFalse_When_PasswordLessThan8()
        {
            var user = new User(Guid.NewGuid(), "James Bond", "james.bond@mi6.com", "1234567", "123456", "+44 3069 990585");

            Assert.False(user.IsValid());
            Assert.Equal(1, user.ValidationResult.Errors.Count);
            Assert.Equal("Senha precisa ter no mínimo 8 caracteres", user.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact]
        public void ReturnFalse_When_PasswordSaltNotProvided()
        {
            var user = new User(Guid.NewGuid(), "James Bond", "james.bond@mi6.com", "james123", "", "+44 3069 990585");

            Assert.False(user.IsValid());
            Assert.Equal(1, user.ValidationResult.Errors.Count);
            Assert.Equal("Senha-chave é obrigatório", user.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact]
        public void ReturnFalse_When_PhoneNotProvided()
        {
            var user = new User(Guid.NewGuid(), "James Bond", "james.bond@mi6.com", "james123", "123456", "");

            Assert.False(user.IsValid());
            Assert.Equal(1, user.ValidationResult.Errors.Count);
            Assert.Equal("Telefone é obrigatório", user.ValidationResult.Errors[0].ErrorMessage);
        }
    }
}