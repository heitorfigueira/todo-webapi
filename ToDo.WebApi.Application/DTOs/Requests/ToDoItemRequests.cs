using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.DTOs.Requests
{
    public record CreateTodoItem(string Description, int ItemListId);
    public record ListTodoItem(string? Description, int? ItemListId);
    public record UpdateTodoItem(int Id, string? Description, int? ItemListId, bool? Done);
}
