using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations
{
    public class CreateTodoListValidator : AbstractValidator<CreateToDoList>
    {
        public CreateTodoListValidator()
        {
            RuleFor(r => r.Description)
                .NotEmpty()
                .Unless(r => r.Description is null);

            RuleFor(r => r.Name).NotEmpty();
        }
    }
}
