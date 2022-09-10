using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Infrastructure.Contexts;
using WebApi.Framework.Data.Repositories.EntityFramework;

namespace ToDo.WebApi.Application.Services
{
    public class TodoListRepository : EntityFrameworkIdentityRepositoryBase<TodoList>, ITodoListRepository
    {
        public TodoListRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
