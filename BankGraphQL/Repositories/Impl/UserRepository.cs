using BankGraphQL.Domain;
using BankGraphQL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankGraphQL.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.User.AsQueryable();
        }

        public User GetById(Guid id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetUsersByIds(List<Guid> userIds)
        {
            return _context.User
                .Where(u => userIds.Contains((Guid)u.Id))
                .ToList();
        }

        public User Save(User user)
        {
            if (user.Id == Guid.Empty || user.Id == null)
            {
                user.Id = Guid.NewGuid();
                _context.User.Add(user);
            }

            _context.SaveChanges();

            return user;
        }
    }
}
