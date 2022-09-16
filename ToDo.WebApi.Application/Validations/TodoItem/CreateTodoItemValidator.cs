using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.TodoItem
{
    public class CreateTodoItemValidator : AbstractValidator<CreateToDoItem>
    {
        public CreateTodoItemValidator()
        {
        }
    }
}
