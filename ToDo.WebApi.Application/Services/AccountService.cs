using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account? Create(Account request)
        {
            var id = _accountRepository.Create(request);
            return _accountRepository.Get(id);
        }

        public Account? Delete(Guid id)
        {
            return _accountRepository.Delete(id);
        }

        public Account? Get(Guid id)
        {
            return _accountRepository.Get(id);
        }
    }
}
