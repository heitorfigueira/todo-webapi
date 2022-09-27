using ErrorOr;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using WebApi.Framework.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ToDo.WebApi.Application.Services
{
    public class AuthService : TransientService, IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly IHashService _hashService;
        private readonly IUserService _userService;

        public AuthService(IJwtService jwtService, IHashService hashService, IUserService userService, IMapper mapper) : base(mapper)
        {
            _jwtService = jwtService;
            _hashService = hashService; 
            _userService = userService;
        }

        public ErrorOr<Session> Signin(AuthRequests.Auth request)
        {
            var user = _userService.Get(request.Email);

            if (user.IsError || user.Value is null || 
                !_hashService.VerifyAgainstHashedPassword(user.Value.Id, user.Value.Password, request.Password))
                return Errors.Authentication.InvalidCredentials;

            var hashedPassword = _jwtService.GenerateTokenFrom(user.Value!);

            if (hashedPassword.IsError)
                return hashedPassword.Errors;

            return new Session()
            {
                Token = hashedPassword.Value,
                Started = DateTime.UtcNow
            };
        }

        public ErrorOr<Session> Signup(AuthRequests.Auth request, User? creatingUser = null)
        {
            var get = _userService.Get(request.Email);

            if (get.IsError)
                return get.Errors;
            else if (get.Value is not null)
                return Errors.Authentication.DuplicateEmail;

            var user = _mapper!.Map<User>(request);
            user.Password = _hashService.HashPassword(user.Id, request.Password);

            var createdUser = _userService.Create(user);

            if (createdUser.IsError)
                return createdUser.Errors;

            var content = _jwtService.GenerateTokenFrom(createdUser.Value);

            if (content.IsError)
                return content.Errors;

            return new Session()
            {
                Token = content.Value,
                Started = DateTime.UtcNow
            };
        }
    }
}
