using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.Auth
{
    public class AuthValidator : AbstractValidator<AuthRequests.Auth>
    {
        public AuthValidator()
        {
            RuleFor(auth => auth.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(auth => auth.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{PropertyName}' must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage(@"'{PropertyName}' must not contain the following characters £ # “” or spaces.");
        }
    }
}
