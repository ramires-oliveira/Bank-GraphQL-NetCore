namespace BankGraphQL.DTO.Request.Account
{
    public class WithdrawDepositAccountRequest
    {
        public string? Number { get; set; }
        public decimal Value { get; set; }
    }
}
