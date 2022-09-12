using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.DTOs.Requests
{
    public record CreateToDoList(string Name, Guid accountId, string? Description, IEnumerable<CreateToDoItem>? Items);
    public record ListToDoList(string? Name, Guid? accountId, string? Description, string? Id, IEnumerable<TodoItem>? Items);
    public record UpdateToDoList(TodoList list);
}
