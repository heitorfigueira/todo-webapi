using ErrorOr;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using WebApi.Framework.DependencyInjection;

namespace ToDo.WebApi.Application.Services
{
    public class AuthService : ScopedService, IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly IHashService _hashService;
        private readonly IUserService _userService;

        public AuthService(IJwtService jwtService, IHashService hashService, IUserService userService)
        {
            _jwtService = jwtService;
            _hashService = hashService; 
            _userService = userService;
        }

        public ErrorOr<Session> Signin(AuthRequests.Auth request)
        {
            var user = _userService.Get(request.Email);

            if (user.IsError || user.Value is null || 
                !_hashService.VerifyAgainstHashedPassword(request.Password, user.Value.Password))
                return Errors.Authentication.InvalidCredentials; //TODO: transform into list of errors, maybe git has the way to do it

            var hashedPassword = _jwtService.GenerateTokenFrom(user.Value!);

            if (hashedPassword.IsError)
                return hashedPassword.Errors;

            return new Session()
            {
                Content = hashedPassword.Value,
                Started = DateTime.UtcNow
            };
        }

        public ErrorOr<bool> Signoff()
        {

            return true;
        }

        public ErrorOr<Session> Signup(AuthRequests.Auth request)
        {
            var user = _userService.Get(request.Email);

            if (user.IsError)
                return user.Errors;
            else if (user.Value is not null)
                return Errors.Authentication.DuplicateEmail;

            User newUser = new()
            {
                Email = request.Email, 
                Password = _hashService.HashPassword(request.Password)
            };

            var createdUser = _userService.Create(newUser);

            if (createdUser.IsError)
                return createdUser.Errors;

            var content = _jwtService.GenerateTokenFrom(createdUser.Value);

            if (content.IsError)
                return content.Errors;

            return new Session()
            {
                Content = content.Value,
                Started = DateTime.UtcNow
            };
        }
    }
}
