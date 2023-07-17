using BankGraphQL.Domain;

namespace BankGraphQL.DTO.Request.Account
{
    public class UpsertAccountRequest: Base
    {
        public Guid? Id { get; set; }
        public string? Number { get; set; }
        public decimal Value { get; set; }
        public Guid UserId { get; set; }
    }
}
