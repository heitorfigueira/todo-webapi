using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.TodoList
{
    public class UpdateTodoListValidator : AbstractValidator<UpdateToDoList>
    {
        public UpdateTodoListValidator()
        {
        }
    }
}
