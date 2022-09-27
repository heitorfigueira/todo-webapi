using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Caching;
using WebApi.Framework.DataAccess.Repositories.Cached;

namespace ToDo.WebApi.Application.Services
{
    public class TodoListRepository : CachedEntityFrameworkIdentityRepositoryBase<TodoList>, ITodoListRepository
    {
        public TodoListRepository(ApplicationContext context, ICachingService cachingService) : base(context, cachingService)
        {
        }
    }
}
