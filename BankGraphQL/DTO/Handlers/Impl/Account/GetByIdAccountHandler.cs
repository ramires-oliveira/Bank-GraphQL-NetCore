using BankGraphQL.Domain;
using BankGraphQL.DTO.Handlers.Interface.Account;
using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.Repositories.Impl;
using BankGraphQL.Repositories.Interface;
using BankGraphQL.Validators.Account;
using FluentValidation;
using HotChocolate.Types.Relay;
using System.ComponentModel.DataAnnotations;

namespace BankGraphQL.DTO.Handlers.Impl.Account
{
    public class GetByIdAccountHandler : IGetByIdAccountHandler
    {
        private readonly IAccountRepository _repository;

        public GetByIdAccountHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public AccountResponse Execute(GetByIdAccountRequest request)
        {
            var validator = new GetByIdAccountValidator().Validate(request);

            if (!validator.IsValid)
            {
                return new AccountResponse
                {
                    Errors = validator.Errors
                };
            }
            var account = _repository.GetById(request.Id);

            if (account == null)
                throw new Exception("Conta não encontrada");

            return new AccountResponse
            {
                Id = (Guid)account.Id,
                Number = account.Number,
                Value = account.Value,
                UserId = account.UserId,
                UserName = account.User.Name,
                Active = account.Active,
                DataDelete = account.DataDelete,
                DataCreate = account.DataCreate,
                DataModification = account.DataModification
            };
        }
    }
}
