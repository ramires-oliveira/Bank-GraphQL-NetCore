using BankGraphQL.Domain;
using BankGraphQL.DTO.Handlers.Impl.Account;
using BankGraphQL.DTO.Handlers.Impl.User;
using BankGraphQL.DTO.Handlers.Interface.Account;
using BankGraphQL.DTO.Handlers.Interface.User;
using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Request.User;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.DTO.Response.User;

namespace BankGraphQL.GraphQL.Query
{
    public class Query
    {
        #region Account

        public AccountsResponse GetAccounts([Service] IGetAllAccountHandler handler)
        {
            return handler.Execute();
        }

        public AccountResponse GetAccount([Service] IGetByIdAccountHandler handler, GetByIdAccountRequest request)
        {
            return handler.Execute(request);
        }

        public WithdrawDepositAccountResponse GetBalance([Service] IBalanceAccountHandler handler, string number)
        {
            return handler.Execute(number);
        }

        #endregion

        #region User

        public UsersResponse GetUsers([Service] IGetAllUserHandler handler)
        {
            return handler.Execute();
        }

        public UserResponse GetUser([Service] IGetByIdUserHandler handler, GetByIdUserRequest request)
        {
            return handler.Execute(request);
        }

        #endregion
    }
}
