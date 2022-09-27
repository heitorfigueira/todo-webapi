using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Interface.Controllers;
using ToDo.WebApi.Tests.Unit.Mocks.Services;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Unit.Setups.Controllers
{
    public static class AuthControllerSetups
    {
        public static AuthController SigninWithCredentialsReturnsSession(Auth auth)
        {
            var mockAuthService = AuthServiceMocks.Mock().SetupSigninWithValidCredentialsReturnsSession(auth);

            return new(mockAuthService.Object);
        }
        public static AuthController SigninWithInvalidCredentialsReturnsInvalidCredentialsError(Auth auth)
        {
            var mockAuthService = AuthServiceMocks.Mock().SetupSigninWithInvalidCredentialsReturnsCreationFailedError(auth);

            return new(mockAuthService.Object);
        }

        public static (AuthController controller, Auth auth) SigninWithValidCredentialsReturnsSession()
        {
            var validAuth = AuthFakers.GenerateSingleAuth();

            return (SigninWithCredentialsReturnsSession(validAuth), validAuth);
        }

        public static (AuthController controller, Auth auth) SigninInvalidCredentialsReturnsInvalidCredentialsError()
        {
            var invalidAuth = AuthFakers.GenerateSingleAuth();

            return (SigninWithInvalidCredentialsReturnsInvalidCredentialsError(invalidAuth), invalidAuth);
        }
    }
}
