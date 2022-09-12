using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities.Relations;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Data.Repositories.EntityFramework;

namespace ToDo.WebApi.Infrastructure.Repositories
{
    public class AccountTodoListRepository : EntityFrameworkIdentityRepositoryBase<AccountTodoList>, IAccountTodoListRepository
    {
        private readonly ApplicationContext applicationContext;
        public AccountTodoListRepository(ApplicationContext context) : base(context)
        {
            applicationContext = context;
        }
    }
}
