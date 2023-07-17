using BankGraphQL.Domain;
using FluentValidation.Results;

namespace BankGraphQL.DTO.Response.Account
{
    public class UpsertAccountResponse
    {
        public Guid Id { get; set; }
        public string? Number { get; set; }
        public decimal Value { get; set; }
        public Guid UserId { get; set; }
        public List<ValidationFailure>? Errors { get; set; }
    }
}
