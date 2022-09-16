using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Application.DTOs.Requests
{
    public record CreateToDoItem(string Description, int ItemListId);
    public record ListToDoItem(string? Description, int? ItemListId);
    public record UpdateToDoItem(int Id, string? Description, int? ItemListId, bool? Done);
}
