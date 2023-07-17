using BankGraphQL.Domain;
using BankGraphQL.DTO.Handlers.Impl.Account;
using BankGraphQL.DTO.Handlers.Impl.User;
using BankGraphQL.DTO.Handlers.Interface.Account;
using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Request.User;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.GraphQL.Mutations;
using BankGraphQL.Repositories;
using BankGraphQL.Repositories.Interface;
using Bogus;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestsHandlers
    {
        #region Account

        [Fact]
        public void CannotEditNonExistentAccount()
        {
            var request = new UpsertAccountRequest
            {
                Id = Guid.NewGuid(),
                Number = "54321",
                Value = 1000
            };

            var mockRepository = new Mock<IAccountRepository>();

            mockRepository.Setup(repository => repository.GetById((Guid)request.Id))
                .Returns((BankGraphQL.Domain.Account)null);

            var handler = new UpsertAccountHandler(mockRepository.Object, null);

            Assert.Throws<Exception>(() => handler.Execute(request));
        }

        [Fact]
        public void CannotRegisterAccountWithExistingNumber()
        {
            var account = new Account
            {
                Number = "54321",
                Value = 1000
            };

            var request = new UpsertAccountRequest
            {
                Number = "54321",
                Value = 1000
            };

            var mockRepository = new Mock<IAccountRepository>();

            mockRepository.Setup(repository => repository.GetByNumber(request.Number))
                .Returns(account);

            var handler = new UpsertAccountHandler(mockRepository.Object, null);

            Assert.Throws<Exception>(() => handler.Execute(request));
        }

        [Fact]
        public void YouCannotWithdrawAnAmountGreaterThanTheBalance()
        {
            var account = new Account
            {
                Number = "54321",
                Value = 1000
            };

            var number = "54321";
            var value = 1500;

            var mockRepository = new Mock<IAccountRepository>();

            mockRepository.Setup(repository => repository.GetByNumber(number))
                .Returns(account);

            var handler = new WithdrawAccountHandler(mockRepository.Object);

            var exception = Assert.Throws<Exception>(() => handler.Execute(number, value));

            Assert.Equal("Saldo insuficiente", exception.Message);
        }

        [Fact]
        public void CannotWithdrawFromNonExistentAccount()
        {
            var number = "54321";
            var value = 500;

            var mockRepository = new Mock<IAccountRepository>();

            mockRepository.Setup(repository => repository.GetByNumber(number))
                .Returns((Account)null);

            var handler = new WithdrawAccountHandler(mockRepository.Object);

            var exception = Assert.Throws<Exception>(() => handler.Execute("12345", value));

            Assert.Equal("Conta não encontrada", exception.Message);
        }

        [Fact]
        public void CannotRegisterAccountWithNonExistentUser()
        {
            var request = new UpsertAccountRequest
            {
                Number = "12345",
                Value = 2000,
                UserId = Guid.NewGuid()
            };

            var mockRepository = new Mock<IAccountRepository>();
            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(repository => repository.GetAll())
                .Returns(Enumerable.Empty<User>().AsQueryable());

            var handler = new UpsertAccountHandler(mockRepository.Object, mockUserRepository.Object);

            Assert.Throws<Exception>(() => handler.Execute(request));
        }

        [Theory]
        [InlineData("12345", 500, 500)]
        [InlineData("54321", 200, 800)]
        public void WithdrawFromAccount(string number, decimal value, decimal valueExpected)
        {
            var account = new Account
            {
                Number = number,
                Value = 1000
            };

            var mockRepository = new Mock<IAccountRepository>();

            mockRepository.Setup(repository => repository.GetByNumber(number))
                .Returns(account);

            var handler = new WithdrawAccountHandler(mockRepository.Object);

            var response = handler.Execute(number, value);

            Assert.Equal(valueExpected, response.Value);
        }

        #endregion

        #region User

        [Fact]
        public void CannotEditNonExistentUser()
        {
            var request = new UpsertUserRequest
            {
                Id = Guid.NewGuid(),
                Name = "User",
                Email = "user@user.com"
            };

            var mockRepository = new Mock<IUserRepository>();

            mockRepository.Setup(repository => repository.GetById((Guid)request.Id))
                .Returns((BankGraphQL.Domain.User)null);

            var handler = new UpsertUserHandler(mockRepository.Object);

            Assert.Throws<Exception>(() => handler.Execute(request));
        }

        #endregion
    }
}
