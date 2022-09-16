using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.TodoItem
{
    public class ListTodoItemValidator : AbstractValidator<ListTodoItem>
    {
        public ListTodoItemValidator()
        {

            RuleFor(update => update.Description)
                .NotEmpty().Unless(list => list.Description is null)
                .NotNull().Unless(list => list.ItemListId is not null);

            RuleFor(update => update.ItemListId)
                .NotEmpty().Unless(list => list.ItemListId is null)
                .NotNull().Unless(list => list.Description is not null);
        }
    }
}
