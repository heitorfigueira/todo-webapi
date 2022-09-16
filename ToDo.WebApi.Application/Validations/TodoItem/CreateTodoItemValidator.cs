using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.TodoItem
{
    public class CreateTodoItemValidator : AbstractValidator<CreateTodoItem>
    {
        public CreateTodoItemValidator()
        {
            RuleFor(update => update.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(list => list.ItemListId)
                .NotEmpty()
                .NotNull();
        }
    }
}
