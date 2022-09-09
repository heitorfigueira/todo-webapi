
using ToDo.WebApi.Domain.Entities;
using WebApi.Framework.Data.Repositories;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface ITodoItemRepository : IRepositoryIdentity<TodoItem>
    {
    }
}
