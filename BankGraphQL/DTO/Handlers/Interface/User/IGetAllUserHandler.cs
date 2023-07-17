using BankGraphQL.DTO.Response.Account;
using BankGraphQL.DTO.Response.User;

namespace BankGraphQL.DTO.Handlers.Interface.User
{
    public interface IGetAllUserHandler
    {
        UsersResponse Execute();
    }
}
