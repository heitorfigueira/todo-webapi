using ToDo.WebApi.Application.Contracts.Repositories;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Data.Repositories.EntityFramework;

namespace ToDo.WebApi.Application.Services
{
    public class TodoItemRepository : EntityFrameworkIdentityRepositoryBase<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
