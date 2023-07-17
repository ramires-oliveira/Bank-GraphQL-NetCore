using BankGraphQL.DTO.Request.Account;
using FluentValidation;

namespace BankGraphQL.Validators.Account
{
    public class UpsertAccountValidator : AbstractValidator<UpsertAccountRequest>
    {
        public UpsertAccountValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(5)
                .WithName("conta");

            RuleFor(x => x.Value)
                .NotEmpty()
                .NotNull()
                .WithName("saldo");
        }
    }
}
