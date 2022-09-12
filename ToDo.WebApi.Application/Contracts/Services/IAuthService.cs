using ErrorOr;
using ToDo.WebApi.Application.DTOs.ValueObject;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface IAuthService
    {
        public ErrorOr<Session> Signin(Auth request);
        public ErrorOr<bool> Signoff();
        public ErrorOr<Session> Signup(Auth request);
    }
}
