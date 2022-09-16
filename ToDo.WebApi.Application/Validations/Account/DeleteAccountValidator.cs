using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.Account
{
    public class DeleteAccountValidator : AbstractValidator<DeleteAccount>
    {
        public DeleteAccountValidator()
        {
            RuleFor(delete => delete.Id).NotEmpty().NotNull();
        }
    }
}
