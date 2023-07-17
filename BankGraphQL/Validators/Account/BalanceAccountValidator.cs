using BankGraphQL.DTO.Request.Account;
using FluentValidation;
using FluentValidation.Results;

namespace BankGraphQL.Validators.Account
{
    public class BalanceAccountValidator : AbstractValidator<BalanceAccountRequest>
    {
        public BalanceAccountValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(5)
                .WithName("conta");
        }

        public ValidationResult Validate(string number)
        {
            var request = new BalanceAccountRequest { Number = number };
            return Validate(request);
        }
    }
}
