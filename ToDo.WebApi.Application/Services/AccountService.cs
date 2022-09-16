 using ErrorOr;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using WebApi.Framework.DependencyInjection;

namespace ToDo.WebApi.Application.Services
{
    public class AccountService : ScopedService, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public ErrorOr<Account> Create(CreateAccount request)
        {
            Account newAccount = new()
            {
                Created = DateTime.Now,
                CreatedBy = "", // TODO: get from user claims
                Type = request.Type,
                Name = request.Name,
                UserId = request.UserId
            };

            var user = _accountRepository.Create(newAccount);

            if (user is null)
                return Errors.Repository.CreationFailed;

            return user;
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

            account.Updated = DateTime.Now;
            account.UpdatedByUser = ""; // TODO: pull from httpcontext
            account.UpdatedByIP = ""; // TODO: pull from httpcontext

            account.Name = request.Name ?? account.Name;
            account.Type = request.Type ?? account.Type;

            var accountUpdated = _accountRepository.Update(account);

            if (!accountUpdated)
                return Errors.Repository.UpdateFailed;

            return account;
        }
    }
}
