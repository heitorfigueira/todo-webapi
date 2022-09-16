using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.TodoItem
{
    public class UpdateTodoItemValidator : AbstractValidator<UpdateToDoItem>
    {
        public UpdateTodoItemValidator()
        {
        }
    }
}
