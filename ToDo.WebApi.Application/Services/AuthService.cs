using Throw;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Exceptions;

namespace ToDo.WebApi.Application.Services
{
    public class AuthService : IAuthService
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

        public Session Signin(AuthRequests.Auth request)
        {
            var user = _userService.Get(request.Email);
            // ****
            user.ThrowIfNull(paramName =>
                new AuthException("Email or password do not match, please try again.", null));

            _hashService.VerifyAgainstHashedPassword(request.Password, user.Password)
                .Throw(paramName =>
                    new AuthException("Email or password do not match, please try again.", null)).IfNegative();
            
            return new()
            {
                Content = _jwtService.GenerateTokenFrom(user!),
                Started = DateTime.UtcNow
            };
        }

        public void Signoff()
        {
            //TODO: remove session from header
        }

        public void Signup(AuthRequests.Auth request)
        {
            User user = new()
            {
                Email = request.Email, 
                Password = _hashService.HashPassword(request.Password)
            };

            _userService.Create(user);
        }
    }
}
