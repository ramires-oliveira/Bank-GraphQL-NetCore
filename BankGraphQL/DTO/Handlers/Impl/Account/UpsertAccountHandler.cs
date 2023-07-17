using BankGraphQL.DTO.Handlers.Interface.Account;
using BankGraphQL.DTO.Request.Account;
using BankGraphQL.DTO.Response.Account;
using BankGraphQL.Repositories.Interface;
using BankGraphQL.Validators.Account;

namespace BankGraphQL.DTO.Handlers.Impl.Account
{
    public class UpsertAccountHandler : IUpsertAccountHandler
    {
        private readonly IAccountRepository _repository;
        private readonly IUserRepository _userRepository;

        public UpsertAccountHandler(IAccountRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public UpsertAccountResponse Execute(UpsertAccountRequest request)
        {
            var validator = new UpsertAccountValidator().Validate(request);

            if (!validator.IsValid)
            {
                return new UpsertAccountResponse
                {
                    Errors = validator.Errors
                };
            }

            BankGraphQL.Domain.Account entity;

            if (request.Id != null)
            {
                entity = _repository.GetById((Guid)request.Id);

                if (entity == null)
                {
                    throw new Exception("Conta não encontrada");
                }

                entity.Id = request.Id;
                entity.Number = request.Number;
                entity.Value = request.Value;
                entity.UserId = request.UserId;
                entity.DataModification = DateTime.Now;

                if (request.Active != null)
                {
                    entity.Active = request.Active;
                    entity.DataDelete = request.Active == false ? DateTime.Now : null;
                }
            }
            else
            {
                var accountExistis = _repository.GetByNumber(request.Number);

                if (accountExistis != null)
                {
                    throw new Exception("Número de conta já utilizada.");
                }

                var userExistis = _userRepository.GetAll().FirstOrDefault(x => x.Id == request.UserId);

                if (userExistis == null)
                {
                    throw new Exception("Usuário vinculado à conta não encontrado.");
                }

                entity = new BankGraphQL.Domain.Account();

                entity.Number = request.Number;
                entity.Value = request.Value;
                entity.UserId = request.UserId;
            }

            _repository.Save(entity);

            return new UpsertAccountResponse
            {
                Id = (Guid)entity.Id,
                Number = entity.Number,
                Value = entity.Value,
                UserId = entity.UserId
            };
        }
    }
}
