using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;
using WebApi.Framework.Data.Repositories;

namespace ToDo.WebApi.Application.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        ErrorOr<User?> GetByEmail(string email);
    }
}
