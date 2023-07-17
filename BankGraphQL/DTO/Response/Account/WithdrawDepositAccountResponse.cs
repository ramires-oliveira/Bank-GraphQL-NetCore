using FluentValidation.Results;

namespace BankGraphQL.DTO.Response.Account
{
    public class WithdrawDepositAccountResponse
    {
        public string? Number { get; set; }
        public decimal? Value { get; set; }
        public List<ValidationFailure>? Errors { get; set; }

    }
}
