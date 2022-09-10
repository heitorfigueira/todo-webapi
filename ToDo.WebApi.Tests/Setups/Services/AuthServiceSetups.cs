using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class AuthServiceSetups
    {
        public static Mock<IAuthService> SigninWithCredentialsReturnsSession(Auth auth)
        {
            var mock = new Mock<IAuthService>();
            mock.Setup(service =>
                    service.Signin(auth))
                    .Returns(new Session());

            return mock;
        }
        public static AuthService SigninWithCredentialsReturnsSessionValidJwt(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            string validJwt = "valid jwt";

            var mockUserService = UserServiceSetups.MockGetValidEmailReturnsUser(user);

            var mockHashService = HashServiceSetups.MockVerifyLoginAuthCorrectPasswordReturnsTrue(auth.Password, user.Password);

            var mockJwtService = JwtServiceSetups.MockGenerateTokenValidUserReturnsValidJwt(user, validJwt);

            return new AuthService(mockHashService.Object, mockJwtService.Object, mockUserService.Object);
        }

        public static (AuthService service, Auth auth) SigninValidCredentialsReturnsSessionValidJwt()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SigninWithCredentialsReturnsSessionValidJwt(auth), auth);
        }
    }
}
