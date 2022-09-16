using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.TodoList
{
    public class UpdateTodoListValidator : AbstractValidator<UpdateTodoList>
    {
        public UpdateTodoListValidator()
        {
            RuleFor(update => update.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(update => update.Name)
                .NotEmpty().Unless(update => update.Name is null)
                .NotNull().Unless(update => update.Description is not null);

            RuleFor(update => update.Description)
                .NotEmpty().Unless(update => update.Description is null)
                .NotNull().Unless(update => update.Name is not null);
        }
    }
}
