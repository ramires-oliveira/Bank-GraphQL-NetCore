using BankGraphQL.Domain;
using BankGraphQL.DTO.Response.Account;

namespace BankGraphQL.DTO.Response.User
{
    public class UserResponse: Base
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

    }
}
