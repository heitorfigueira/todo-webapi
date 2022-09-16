using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.TodoList
{
    public class CreateTodoListValidator : AbstractValidator<CreateTodoList>
    {
        public CreateTodoListValidator()
        {
            RuleFor(list => list.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(update => update.Description)
                .NotEmpty().Unless(list => list.Description is null);

            RuleFor(list => list.AccountId)
                .NotEmpty()
                .NotNull();

            RuleFor(list => list.Items)
                .NotEmpty().Unless(list => list.Items is null);
        }
    }
}
