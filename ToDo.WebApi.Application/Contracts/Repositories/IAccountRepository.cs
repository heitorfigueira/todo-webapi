using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;
using WebApi.Framework.Data.Repositories;

namespace ToDo.WebApi.Application.Contracts.Repositories
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
        public IEnumerable<Account> ListAll();
    }
}
