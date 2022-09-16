using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.Account
{
    public class CreateAccountValidator : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidator()
        {
            RuleFor(create => create.Type).NotEmpty().NotNull();
            RuleFor(create => create.Name).NotEmpty().NotNull();
            RuleFor(create => create.UserId).NotEmpty().NotNull();
        }
    }
}
