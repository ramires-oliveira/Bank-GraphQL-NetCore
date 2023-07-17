using BankGraphQL.Domain;
using BankGraphQL.DTO.Handlers.Interface.User;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.DTO.Response.User;
using BankGraphQL.Repositories.Interface;

namespace BankGraphQL.DTO.Handlers.Impl.User
{
    public class GetAllUserHandler: IGetAllUserHandler
    {
        private readonly IUserRepository _repository;

        public GetAllUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public UsersResponse Execute()
        {
            var users = _repository.GetAll()
                .Select(q => new UserResponse
                {
                    Id = (Guid)q.Id,
                    Name = q.Name,
                    Email = q.Email,
                    Active = q.Active,
                    DataDelete = q.DataDelete,
                    DataCreate = q.DataCreate,
                    DataModification = q.DataModification
                })
                .ToList();

            return new UsersResponse
            {
                Users = users
            };
        }
    }
}
