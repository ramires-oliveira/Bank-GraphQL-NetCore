using BankGraphQL.Domain;

namespace BankGraphQL.Repositories.Interface
{
    public interface IAccountRepository
    {
        IQueryable<Account> GetAll();
        Account GetById(Guid id);
        Account GetByNumber(string number);
        Account Save(Account account);
    }
}
