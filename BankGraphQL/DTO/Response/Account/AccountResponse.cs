using BankGraphQL.Domain;
using FluentValidation.Results;

namespace BankGraphQL.DTO.Response.Account
{
    public class AccountResponse: Base
    {
        public Guid Id { get; set; }
        public string? Number { get; set; }
        public decimal Value { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public List<ValidationFailure>? Errors { get; set; }

    }
}
