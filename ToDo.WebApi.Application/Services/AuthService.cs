using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Exceptions;

namespace ToDo.WebApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtProvider;
        private readonly IPasswordService _passwordService;
        private readonly IUserService _userService;

        public AuthService(IPasswordService passwordService, IJwtService jwtProvider, IUserService userService)
        {
            _passwordService = passwordService; 
            _jwtProvider = jwtProvider;
            _userService = userService;
        }

        public Session Signin(AuthRequests.Auth request)
        {
            var user = _userService.Get(request.Email);

            if (user is null || !_passwordService.VerifyLogin(request, user.Password))
                throw new AuthException("Username or password do not match, please try again.", null);
            
            return new()
            {
                Content = _jwtProvider.GenerateTokenFrom(user!),
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
                Password = _passwordService.HashPassword(request.Password)
            };

            _userService.Create(user);
        }
    }
}
