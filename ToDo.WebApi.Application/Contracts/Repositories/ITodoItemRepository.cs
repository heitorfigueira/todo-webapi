
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface ITodoItemRepository
    {
        int Create(TodoItem request);
        TodoItem? Get(int id);
        TodoItem? Delete(int id);
        TodoItem? Delete(TodoItem list);
        bool Update(TodoItem list);
    }
}
