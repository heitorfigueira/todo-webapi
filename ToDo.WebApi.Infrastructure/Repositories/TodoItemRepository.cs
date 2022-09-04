using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.DataAccess.Repositories.EntityFramework;

namespace ToDo.WebApi.Application.Services
{
    public class TodoItemRepository : EntityFrameworkRepositoryBase<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
