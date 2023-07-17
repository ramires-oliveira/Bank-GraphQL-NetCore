using BankGraphQL.DTO.Handlers.Interface.User;
using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Request.User;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.DTO.Response.User;
using BankGraphQL.Repositories.Interface;

namespace BankGraphQL.DTO.Handlers.Impl.User
{
    public class GetByIdUserHandler : IGetByIdUserHandler
    {
        private readonly IUserRepository _repository;

        public GetByIdUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserResponse Execute(GetByIdUserRequest request)
        {
            var user = _repository.GetById(request.Id);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            return new UserResponse
            {
                Id = (Guid)user.Id,
                Name = user.Name,
                Email = user.Email,
                Active = user.Active,
                DataDelete = user.DataDelete,
                DataCreate = user.DataCreate,
                DataModification = user.DataModification
            };
        }
    }
}
