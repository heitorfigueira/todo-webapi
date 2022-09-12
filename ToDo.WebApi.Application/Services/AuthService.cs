using ErrorOr;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Errors;
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
            // ****
            if (user is null || !_hashService.VerifyAgainstHashedPassword(request.Password, user.Password))
                return Errors.Authentication.InvalidCredentials;

            return new Session()
            {
                Content = _jwtService.GenerateTokenFrom(user!),
                Started = DateTime.UtcNow
            };
        }

        public ErrorOr<bool> Signoff()
        {

            return true;
        }

        public ErrorOr<Session> Signup(AuthRequests.Auth request)
        {
            User user = new()
            {
                Email = request.Email, 
                Password = _hashService.HashPassword(request.Password)
            };

            if (_userService.Create(user) is null)
                return Errors.Authentication.InvalidCredentials;

            return new Session()
            {
                Content = _jwtService.GenerateTokenFrom(user),
                Started = DateTime.UtcNow
            };
        }
    }
}
