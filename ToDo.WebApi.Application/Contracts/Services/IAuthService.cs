using ErrorOr;
using ToDo.WebApi.Application.DTOs.Requests;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Domain.Entities;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface IAuthService
    {
        public ErrorOr<Session> Signin(Auth request);
        public ErrorOr<Session> Signup(AuthRequests.Auth request, User? creatingUser = null);
    }
}
