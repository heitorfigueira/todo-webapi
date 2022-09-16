using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations
{
    public class UpdateTodoItemValidator : AbstractValidator<UpdateToDoItem>
    {
        public UpdateTodoItemValidator()
        {
        }
    }
}
