using FluentValidation;
using System.Collections.Generic;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.TodoList
{
    public class ListTodoListValidator : AbstractValidator<ListTodoList>
    {
        public ListTodoListValidator()
        {
            RuleFor(list => list.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(list => list.Name)
                .NotEmpty().Unless(list => list.Name is null)
                .NotNull().Unless(list => (
                    list.Description is not null || 
                    list.AccountId is not null || 
                    list.Items is not null));

            RuleFor(update => update.Description)
                .NotEmpty().Unless(list => list.Description is null)
                .NotNull().Unless(list => (
                    list.Name is not null ||
                    list.AccountId is not null ||
                    list.Items is not null));

            RuleFor(list => list.AccountId)
                .NotEmpty().Unless(list => list.AccountId is null)
                .NotNull().Unless(list => (
                    list.Name is not null ||
                    list.AccountId is not null ||
                    list.Description is not null));

            RuleFor(list => list.Items)
                .NotEmpty().Unless(list => list.Items is null)
                .NotNull().Unless(list => (
                    list.Name is not null ||
                    list.AccountId is not null ||
                    list.Description is not null));
        }
    }
}
