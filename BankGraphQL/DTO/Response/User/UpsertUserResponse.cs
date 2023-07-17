using BankGraphQL.Domain;
using FluentValidation.Results;

namespace BankGraphQL.DTO.Response.User
{
    public class UpsertUserResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<ValidationFailure>? Errors { get; set; }
    }
}
