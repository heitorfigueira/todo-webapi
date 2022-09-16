using ErrorOr;
using Microsoft.AspNetCore.Http;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;
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

        public ErrorOr<Account?> Create(CreateAccount request)
        {
            Account newAccount = new()
            {
                Created = DateTime.Now,
                CreatedBy = "", // TODO: get from user claims
                Type = request.Type,
                Name = request.Name,
                UserId = request.UserId
            };

            var id = _accountRepository.Create(newAccount);
            return _accountRepository.Get(id);
        }

        public ErrorOr<Account?> Delete(Guid id)
        {
            return _accountRepository.Delete(id);
        }

        public ErrorOr<Account?> Get(Guid id)
        {
            return _accountRepository.Get(id);
        }

        public ErrorOr<IEnumerable<Account>> List(Account? request)
        {
            var list = _accountRepository.ListAll().ToList();
            return list;
        }


        public ErrorOr<Account?> Update(UpdateAccount request)
        {
            var account = _accountRepository.Get(request.Id);

            if (account is not null && 
               (request.Name is not null || request.Type is not null))
            {
                account.Updated = DateTime.Now;
                account.UpdatedByUser = ""; // TODO: pull from httpcontext
                account.UpdatedByIP = ""; // TODO: pull from httpcontext

                account.Name = request.Name ?? account.Name;
                account.Type = request.Type ?? account.Type;

                _accountRepository.Update(account);
            }

            return account;
        }
    }
}
