using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Response.Account;

namespace BankGraphQL.DTO.Handlers.Interface.Account
{
    public interface IBalanceAccountHandler
    {
        WithdrawDepositAccountResponse Execute(string number);
    }
}
