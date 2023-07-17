﻿using BankGraphQL.DTO.Handlers.Interface.Account;
using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.Repositories.Interface;
using BankGraphQL.Validators.Account;

namespace BankGraphQL.DTO.Handlers.Impl.Account
{
    public class DepositAccountHandler: IDepositAccountHandler
    {
        private readonly IAccountRepository _repository;

        public DepositAccountHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public WithdrawDepositAccountResponse Execute(string number, decimal value)
        {
            var validator = new WithdrawDepositAccountValidator().Validate(number, value);

            if (!validator.IsValid)
            {
                return new WithdrawDepositAccountResponse
                {
                    Errors = validator.Errors
                };
            }

            var account = _repository.GetByNumber(number);

            if (account == null)
                throw new Exception("Conta não encontrada");

            account.Value += value;

            _repository.Save(account);

            return new WithdrawDepositAccountResponse
            {
                Number = account.Number,
                Value = account.Value
            };
        }
    }
}
