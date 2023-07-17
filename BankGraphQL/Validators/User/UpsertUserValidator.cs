using BankGraphQL.DTO.Request.User;
using FluentValidation;

namespace BankGraphQL.Validators.User
{
    public class UpsertUserValidator : AbstractValidator<UpsertUserRequest>
    {
        public UpsertUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(20)
                .WithName("nome");

            RuleFor(x => x.Email)
                .MinimumLength(10)
                .MaximumLength(50)
                .WithName("email");
        }
    }
}
