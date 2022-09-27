 using ErrorOr;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using WebApi.Framework.DependencyInjection;
using AutoMapper;

namespace ToDo.WebApi.Application.Services
{
    public class AccountService : TransientService, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository, IMapper mapper) : base(mapper)
        {
            _accountRepository = accountRepository;
        }

        public ErrorOr<Account> Create(CreateAccount request)
        {
            var account = _accountRepository.Create(_mapper!.Map<Account>(request));

            if (account is null)
                return Errors.Repository.CreationFailed;

            return account;
        }

        public ErrorOr<Account> Delete(Guid id)
        {
            var account = _accountRepository.Delete(id);

            if (account is null)
                return Errors.Repository.DeletionFailed;

            return account;

        }

        public ErrorOr<Account?> Get(Guid id)
        {
            var account = _accountRepository.Get(id);

            return account;
        }

        public ErrorOr<Account> Update(UpdateAccount request)
        {
            var account = _accountRepository.Get(request.Id);

            if (account is null)
                return Errors.Repository.NotFound;

            account.Updated = DateTime.UtcNow;
            //account.UpdatedBy = ""; // TODO: pull from httpcontext
            account.UpdatedByIP = ""; // TODO: pull from httpcontext

            account.Name = request.Name ?? account.Name;
            account.TypeId = request.TypeId ?? account.TypeId;

            var accountUpdated = _accountRepository.Update(account);

            if (!accountUpdated)
                return Errors.Repository.UpdateFailed;

            return account;
        }
    }
}
