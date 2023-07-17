using BankGraphQL.DTO.Request.Account;
using FluentValidation;

namespace BankGraphQL.Validators.Account
{
    public class GetByIdAccountValidator : AbstractValidator<GetByIdAccountRequest>
    {
        public GetByIdAccountValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithName("id");
        }
    }
}
