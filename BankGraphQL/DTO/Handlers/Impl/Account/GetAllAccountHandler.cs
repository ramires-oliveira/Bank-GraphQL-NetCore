using BankGraphQL.Domain;
using BankGraphQL.DTO.Handlers.Interface.Account;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.Repositories.Impl;
using BankGraphQL.Repositories.Interface;

namespace BankGraphQL.DTO.Handlers.Impl.Account
{
    public class GetAllAccountHandler: IGetAllAccountHandler
    {
        private readonly IAccountRepository _repository;
        private readonly IUserRepository _userRepository;

        public GetAllAccountHandler(IAccountRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public AccountsResponse Execute()
        {
            var accounts = _repository.GetAll()
                .Select(q => new AccountResponse
                {
                    Id = (Guid)q.Id,
                    Number = q.Number,
                    Value = q.Value,
                    UserId = q.UserId,
                    Active = q.Active,
                    DataDelete = q.DataDelete,
                    DataCreate = q.DataCreate,
                    DataModification = q.DataModification
                })
                .ToList();

            var userIds = accounts.Select(a => a.UserId).Distinct().ToList();
            var users = _userRepository.GetUsersByIds(userIds);

            foreach (var account in accounts)
            {
                var user = users.FirstOrDefault(u => u.Id == account.UserId);
                if (user != null)
                {
                    account.UserName = user.Name;
                }
            }

            return new AccountsResponse
            {
                Accounts = accounts
            };
        }
    }
}
