using FluentValidation;
using ToDo.WebApi.Application.DTOs.Requests;

namespace ToDo.WebApi.Application.Validations.Auth
{
    public class AuthValidator : AbstractValidator<AuthRequests.Auth>
    {
        public AuthValidator()
        {
        }
    }
}
