using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Entities.Relations;
using WebApi.Framework.Data.Repositories;

namespace ToDo.WebApi.Application.Contracts.Repositories
{
    public interface IAccountTodoListRepository : IRepositoryIdentity<AccountTodoList>
    {
    }
}
