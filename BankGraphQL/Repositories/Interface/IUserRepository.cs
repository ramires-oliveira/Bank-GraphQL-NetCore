using BankGraphQL.Domain;

namespace BankGraphQL.Repositories.Interface
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User GetById(Guid id);
        List<User> GetUsersByIds(List<Guid> userIds);
        User Save(User account);
    }
}
