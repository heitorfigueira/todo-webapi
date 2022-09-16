using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations
{
    public class ListTodoItemValidator : AbstractValidator<ListToDoList>
    {
        public ListTodoItemValidator()
        {
            RuleFor(r => r.Description)
                .NotEmpty()
                .Unless(r => r.Description is null);

            RuleFor(r => r.Name).NotEmpty();
        }
    }
}
