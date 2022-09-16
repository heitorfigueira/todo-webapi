using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.TodoItem
{
    public class UpdateTodoItemValidator : AbstractValidator<UpdateTodoItem>
    {
        public UpdateTodoItemValidator()
        {
            RuleFor(update => update.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(update => update.Description)
                .NotEmpty().Unless(update => update.Description is null)
                .NotNull().Unless(update => 
                    update.ItemListId is not null || 
                    update.Done is not null);

            RuleFor(update => update.ItemListId)
                .NotEmpty().Unless(update => update.ItemListId is null)
                .NotNull().Unless(update =>
                    update.Description is not null ||
                    update.Done is not null);

            RuleFor(update => update.Done)
                .NotEmpty().Unless(update => update.Done is null)
                .NotNull().Unless(update =>
                    update.Description is not null ||
                    update.ItemListId is not null);
        }
    }
}
