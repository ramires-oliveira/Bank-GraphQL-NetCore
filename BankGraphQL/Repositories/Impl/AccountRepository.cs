using BankGraphQL.Domain;
using BankGraphQL.Repositories.Interface;

namespace BankGraphQL.Repositories.Impl
{
    public class AccountRepository: IAccountRepository
    {
        private readonly Context _context;

        public AccountRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Account> GetAll()
        {
            return _context.Account.AsQueryable();
        }

        public Account GetById(Guid id)
        {
            return _context.Account.FirstOrDefault(x => x.Id == id);
        }

        public Account GetByNumber(string number)
        {
            return _context.Account.FirstOrDefault(x => x.Number == number);
        }

        public Account Save(Account account)
        {
            if (account.Id == Guid.Empty || account.Id == null)
            {
                account.Id = Guid.NewGuid();
                _context.Account.Add(account);
            }

            _context.SaveChanges();

            return account;
        }
    }
}
