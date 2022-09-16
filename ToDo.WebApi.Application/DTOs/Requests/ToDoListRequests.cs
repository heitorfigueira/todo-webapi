using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.DTOs.Requests
{
    public record CreateTodoList(string Name, Guid AccountId, string? Description, IEnumerable<CreateTodoItem>? Items);
    public record ListTodoList(string? Name, Guid? AccountId, string? Description, int Id, IEnumerable<TodoItem>? Items);
    public record UpdateTodoList(int Id, string? Name, string? Description);
}
