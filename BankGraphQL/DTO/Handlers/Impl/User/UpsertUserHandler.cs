using BankGraphQL.Domain;
using BankGraphQL.DTO.Handlers.Interface.User;
using BankGraphQL.DTO.Request.User;
using BankGraphQL.DTO.Response.User;
using BankGraphQL.Repositories.Interface;
using BankGraphQL.Validators.User;

namespace BankGraphQL.DTO.Handlers.Impl.User
{
    public class UpsertUserHandler : IUpsertUserHandler
    {
        private readonly IUserRepository _repository;

        public UpsertUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public UpsertUserResponse Execute(UpsertUserRequest request)
        {
            var validator = new UpsertUserValidator().Validate(request);

            if (!validator.IsValid)
            {
                return new UpsertUserResponse
                {
                    Errors = validator.Errors
                };
            }

            BankGraphQL.Domain.User entity;

            if (request.Id != null)
            {
                entity = _repository.GetById((Guid)request.Id);

                if (entity == null)
                {
                    throw new Exception("Usuário não encontrado");
                }

                entity.Id = request.Id;
                entity.Name = request.Name;
                entity.Email = request.Email;
                entity.DataModification = DateTime.Now;

                if (request.Active != null)
                {
                    entity.Active = request.Active;
                    entity.DataDelete = request.Active == false ? DateTime.Now : null;
                }
            }
            else
            {
                entity = new BankGraphQL.Domain.User();

                entity.Name = request.Name;
                entity.Email = request.Email;
            }

            _repository.Save(entity);

            return new UpsertUserResponse
            {
                Id = (Guid)entity.Id,
                Name = entity.Name,
                Email = entity.Email,
            };
        }
    }
}
