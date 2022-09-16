
using ToDo.WebApi.Domain.Entities;
using WebApi.Framework.Data.Repositories;

namespace ToDo.WebApi.Application.Contracts.Repositories
{
    public interface ITodoItemRepository : IRepositoryIdentity<TodoItem>
    {
    }
}
