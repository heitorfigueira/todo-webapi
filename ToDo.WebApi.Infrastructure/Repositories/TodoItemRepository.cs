using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Caching;
using WebApi.Framework.DataAccess.Repositories.Cached;

namespace ToDo.WebApi.Application.Services
{
    public class TodoItemRepository : CachedEntityFrameworkIdentityRepositoryBase<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(ApplicationContext context, ICachingService cachingService) : base(context, cachingService)
        {
        }
    }
}
