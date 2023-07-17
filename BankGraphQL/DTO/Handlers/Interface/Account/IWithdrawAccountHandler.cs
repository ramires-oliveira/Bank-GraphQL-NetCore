﻿using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Response.Account;

namespace BankGraphQL.DTO.Handlers.Interface.Account
{
    public interface IWithdrawAccountHandler
    {
        WithdrawDepositAccountResponse Execute(string number, decimal value);
    }
}
