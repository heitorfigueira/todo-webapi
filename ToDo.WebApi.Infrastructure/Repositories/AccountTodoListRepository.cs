using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities.Relations;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Caching;
using WebApi.Framework.DataAccess.Repositories.Cached;

namespace ToDo.WebApi.Infrastructure.Repositories
{
    public class AccountTodoListRepository : CachedEntityFrameworkIdentityRepositoryBase<AccountTodoList>, IAccountTodoListRepository
    {
        private readonly ApplicationContext applicationContext;
        public AccountTodoListRepository(ApplicationContext context, ICachingService cachingService) : base(context, cachingService)
        {
            applicationContext = context;
        }
    }
}
