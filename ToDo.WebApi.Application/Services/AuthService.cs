using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.DTOs.ValueObject;

namespace ToDo.WebApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly IPasswordService _passwordService;

        public AuthService(IPasswordService passwordService, IJwtService jwtService)
        {
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        public Session Signin(AuthRequests.Auth request)
        {
            throw new NotImplementedException();
        }

        public void Signoff()
        {
            throw new NotImplementedException();
        }

        public void Signup(AuthRequests.Auth request)
        {
            throw new NotImplementedException();
        }
    }
}
