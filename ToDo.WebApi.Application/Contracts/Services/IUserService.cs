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
    public interface IUserService
    {
        ErrorOr<User> Create(User user);
        ErrorOr<User> Delete(Guid id);
        ErrorOr<User?> Get(string email);
        ErrorOr<User?> Get(Guid id);
    }
}
