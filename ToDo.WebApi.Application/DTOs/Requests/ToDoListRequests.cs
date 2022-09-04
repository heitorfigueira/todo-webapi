namespace ToDo.WebApi.Application.DTOs.Requests
{
    public record CreateToDoList(string Name, string? Description, IEnumerable<CreateToDoItem>? Items);
}
