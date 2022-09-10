using Bogus;
using Moq;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Interface.Controllers;
using ToDo.WebApi.Tests.Setups.Services;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Setups.Controllers
{
    public static class AuthControllerSetups
    {
        public static AuthController SigninWithCredentialsReturnsSession(Auth auth)
        {
            var mockAuthService = AuthServiceSetups.SigninWithCredentialsReturnsSession(auth);

            return new(mockAuthService.Object);
        }

        public static (AuthController controller, Auth auth) SigninValidCredentialsReturnsSession()
        {
            var validAuth = AuthFakers.GenerateSingleAuth();

            var mockAuthService = AuthServiceSetups.SigninWithCredentialsReturnsSession(validAuth);

            return (SigninWithCredentialsReturnsSession(validAuth), validAuth);
        }
    }
}
