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

        public AuthService(IHashService hashService, IJwtService jwtService, IUserService userService)
        {
            _hashService = hashService; 
            _jwtService = jwtService;
            _userService = userService;
        }

        public Session Signin(AuthRequests.Auth request)
        {
            var user = _userService.Get(request.Email);

            if (user is null || !_hashService.VerifyAgainstHashedPassword(request.Password, user.Password))
                throw new AuthException("Username or password do not match, please try again.", null);
            
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
