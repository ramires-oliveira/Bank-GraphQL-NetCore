using BankGraphQL.DTO.Response.Account;

namespace BankGraphQL.DTO.Handlers.Interface.Account
{
    public interface IGetAllAccountHandler
    {
        AccountsResponse Execute();
    }
}
