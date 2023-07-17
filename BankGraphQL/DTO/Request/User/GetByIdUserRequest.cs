using BankGraphQL.Domain;

namespace BankGraphQL.DTO.Request.User
{
    public class GetByIdUserRequest : Base
    {
        public Guid Id { get; set; }
    }
}
