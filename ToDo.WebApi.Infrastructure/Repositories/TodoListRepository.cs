using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.DataAccess.Repositories.EntityFramework;

namespace ToDo.WebApi.Application.Services
{
    public class TodoListRepository : EntityFrameworkRepositoryBase<TodoList>, ITodoListRepository
    {
        public TodoListRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
