using BankGraphQL.DTO.Handlers.Interface.Account;
using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.Repositories.Interface;
using BankGraphQL.Validators.Account;

namespace BankGraphQL.DTO.Handlers.Impl.Account
{
    public class BalanceAccountHandler: IBalanceAccountHandler
    {
        private readonly IAccountRepository _repository;

        public BalanceAccountHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public WithdrawDepositAccountResponse Execute(string number)
        {
            var validator = new BalanceAccountValidator().Validate(number);

            if (!validator.IsValid)
            {
                return new WithdrawDepositAccountResponse
                {
                    Errors = validator.Errors
                };
            }

            var account = _repository.GetByNumber(number);

            if (account == null)
                throw new Exception("Conta não encontrada");

            return new WithdrawDepositAccountResponse
            {
                Value = account.Value
            };
        }

    }
}
