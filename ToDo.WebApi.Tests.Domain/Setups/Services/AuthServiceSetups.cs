using AutoFixture;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain.Errors;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class AuthServiceSetups
    {
        public static Mock<IAuthService> Mock()
        {
            return new Mock<IAuthService>();
        }

        #region Signin
        public static Mock<IAuthService> SetupSigninWithValidCredentialsReturnsSession(this Mock<IAuthService> mock, Auth auth)
        {
            mock.Setup(service =>
                    service.Signin(auth))
                    .Returns(new Session());

            return mock;
        }

        public static Mock<IAuthService> SetupSigninWithInvalidCredentialsReturnsError(this Mock<IAuthService> mock, Auth auth)
        {
            mock.Setup(service =>
                    service.Signin(auth))
                    .Returns(Errors.Authentication.InvalidCredentials);

            return mock;
        }

        public static AuthService SigninWithValidCredentialsReturnsSession(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            string validJwt = "valid jwt";

            var mockUserService = UserServiceSetups.Mock().SetupGetValidEmailReturnsUser(auth.Email, user);

            var mockHashService = HashServiceSetups.Mock().SetupVerifyLoginAuthCorrectPasswordReturnsTrue(auth.Password, user.Password);

            var mockJwtService = JwtServiceSetups.MockGenerateTokenValidUserReturnsJwt(user, validJwt);

            return new AuthService(mockJwtService.Object, mockHashService.Object, mockUserService.Object);
        }

        public static AuthService SigninWithInvalidEmailReturnsInvalidCredentialsError(Auth auth)
        {
            var mockUserService = UserServiceSetups.Mock().SetupGetInvalidEmailReturnsNull(auth.Email);

            return new AuthService(JwtServiceSetups.Mock().Object, HashServiceSetups.Mock().Object, mockUserService.Object);
        }

        public static AuthService SigninWithIncorrectPasswordReturnsInvalidCredentialsError(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService = UserServiceSetups.Mock().SetupGetValidEmailReturnsUser(auth.Email, user);

            var mockHashService = HashServiceSetups.Mock().SetupVerifyLoginAuthIncorrectPasswordReturnsFalse(auth.Password, user.Password);

            return new AuthService(JwtServiceSetups.Mock().Object, mockHashService.Object, mockUserService.Object);
        }

        public static (AuthService service, Auth auth) SigninValidCredentialsReturnsSession()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SigninWithValidCredentialsReturnsSession(auth), auth);
        }

        public static (AuthService service, Auth auth) SigninInvalidEmailReturnsInvalidCredentialsError()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SigninWithInvalidEmailReturnsInvalidCredentialsError(auth), auth);
        }

        public static (AuthService service, Auth auth) SigninIncorrectPasswordReturnsInvalidCredentialsError()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SigninWithInvalidEmailReturnsInvalidCredentialsError(auth), auth);
        }

        #endregion

        #region Signup
        public static Mock<IAuthService> MockSignupWithValidCredentialsReturnsSession(Auth auth)
        {
            var mock = new Mock<IAuthService>();
            mock.Setup(service =>
                    service.Signup(auth))
                    .Returns(new Session());

            return mock;
        }

        public static AuthService SignupValidCredentialsReturnsSession(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();
            user.Email = auth.Email;

            string validJwt = "valid jwt";

            var mockUserService = UserServiceSetups.Mock()
                .SetupCreateReturnsUser(user)
                .SetupGetInvalidEmailReturnsNull(auth.Email);

            var mockHashService = HashServiceSetups.Mock().SetupHashPasswordReturnsHashedPassword(auth.Password, user.Password);

            var mockJwtService = JwtServiceSetups.MockGenerateTokenValidUserReturnsJwt(user, validJwt);

            return new AuthService(mockJwtService.Object, mockHashService.Object, mockUserService.Object);
        }

        public static AuthService SignupWithDuplicateEmailReturnsDuplicateEmailErrors(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService = 
                UserServiceSetups.Mock().SetupGetValidEmailReturnsUser(auth.Email, user);

            return new AuthService(JwtServiceSetups.Mock().Object, HashServiceSetups.Mock().Object, mockUserService.Object);
        }

        public static AuthService SignupOnCreationFailureReturnsCreationFailureError(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService = 
                UserServiceSetups.Mock()
                    .SetupGetInvalidEmailReturnsNull(auth.Email)
                    .SetupCreateReturnsNull(user);

            var mockHashService = HashServiceSetups.Mock().SetupHashPasswordReturnsHashedPassword(auth.Password, user.Password);

            return new AuthService(
                JwtServiceSetups.Mock().Object,
                mockHashService.Object,
                mockUserService.Object);
        }

        public static (AuthService service, Auth auth) SignupValidCredentialsReturnsSession()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SignupValidCredentialsReturnsSession(auth), auth);
        }

        public static (AuthService service, Auth auth) SignupWithDuplicateEmailReturnsDuplicateEmailErrors()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SignupWithDuplicateEmailReturnsDuplicateEmailErrors(auth), auth);
        }

        public static (AuthService service, Auth auth) SignupOnCreationFailureReturnsCreationFailureError()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SignupOnCreationFailureReturnsCreationFailureError(auth), auth);
        }
        #endregion
    }
}
