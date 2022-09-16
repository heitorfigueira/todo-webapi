﻿using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.Account
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccount>
    {
        public UpdateAccountValidator()
        {
            RuleFor(update => update.Id).NotEmpty().NotNull();

            RuleFor(update => update.Name)
                .NotEmpty().Unless(update => update.Name is null)
                .NotNull().Unless(update => update.Type is not null);

            RuleFor(update => update.Type)
                .NotEmpty().Unless(update => update.Type is null)
                .NotNull().Unless(update => update.Name is not null);
        }
    }
}
