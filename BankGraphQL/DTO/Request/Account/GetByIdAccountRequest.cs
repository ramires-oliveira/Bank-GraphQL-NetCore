using BankGraphQL.Domain;

namespace BankGraphQL.DTO.Request.Account
{
    public class GetByIdAccountRequest : Base
    {
        public Guid Id { get; set; }
    }
}
