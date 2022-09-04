
using ToDo.WebApi.Domain.Entities;
using WebApi.Framework.DataAccess.Repositories;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
    }
}
