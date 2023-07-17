using BankGraphQL.Domain;

namespace BankGraphQL.DTO.Request.User
{
    public class UpsertUserRequest : Base
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
