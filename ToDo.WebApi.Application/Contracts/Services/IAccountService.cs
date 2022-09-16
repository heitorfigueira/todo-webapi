using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Domain.Entities;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface IAccountService
    {
        ErrorOr<Account> Create(CreateAccount request);
        ErrorOr<Account> Delete(Guid id);
        ErrorOr<Account?> Get(Guid id);
        ErrorOr<Account> Update(UpdateAccount request);
    }
}
