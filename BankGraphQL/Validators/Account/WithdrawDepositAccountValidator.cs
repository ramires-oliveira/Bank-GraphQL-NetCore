using BankGraphQL.DTO.Request.Account;
using FluentValidation;
using FluentValidation.Results;
using System.Numerics;

namespace BankGraphQL.Validators.Account
{
    public class WithdrawDepositAccountValidator : AbstractValidator<WithdrawDepositAccountRequest>
    {
        public WithdrawDepositAccountValidator()
        {
            RuleFor(x => x.Number)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(20)
                .WithName("conta");

            RuleFor(x => x.Value)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .Must(BeInteger)
            .WithMessage("O campo {PropertyName} deve ser um valor inteiro.")
            .WithName("valor");
        }

        public ValidationResult Validate(string number, decimal value)
        {
            var request = new WithdrawDepositAccountRequest { Number = number, Value = value };
            return Validate(request);
        }

        private bool BeInteger(decimal value)
        {
            return value == Math.Floor(value);
        }
    }
}
