using BankGraphQL.DTO.Handlers.Interface.Account;
using BankGraphQL.DTO.Handlers.Interface.User;
using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Request.User;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.DTO.Response.User;

namespace BankGraphQL.GraphQL.Mutations
{
    public class Mutation
    {
        #region Account

        public UpsertAccountResponse UpsertAccount([Service] IUpsertAccountHandler handler, UpsertAccountRequest request)
        {
            return handler.Execute(request);
        }

        public WithdrawDepositAccountResponse Sacar([Service] IWithdrawAccountHandler handler, string number, decimal value)
        {
            return handler.Execute(number, value);
        }

        public WithdrawDepositAccountResponse Depositar([Service] IDepositAccountHandler handler, string number, decimal value)
        {
            return handler.Execute(number, value);
        }

        #endregion

        #region User

        public UpsertUserResponse UpsertUser([Service] IUpsertUserHandler handler, UpsertUserRequest request)
        {
            return handler.Execute(request);
        }

        #endregion
    }
}
