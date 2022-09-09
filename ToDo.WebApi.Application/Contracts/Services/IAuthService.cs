using ToDo.WebApi.Application.DTOs.ValueObject;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Application.Contracts.Services
{
    public interface IAuthService
    {
        public Session Signin(Auth request);
        public void Signoff();
        public void Signup(Auth request);
    }
}
