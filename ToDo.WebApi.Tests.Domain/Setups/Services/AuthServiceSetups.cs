using AutoFixture;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class AuthServiceSetups
    {
        #region Signin
        public static AuthService SigninWithValidCredentialsReturnsSession(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            string validJwt = "valid jwt";

            var mockUserService = UserServiceMocks.Mock().SetupGetValidEmailReturnsUser(auth.Email, user);

            var mockHashService = HashServiceMocks.Mock().SetupVerifyLoginAuthCorrectPasswordReturnsTrue(auth.Password, user.Password);

            var mockJwtService = JwtServiceMocks.Mock().SetupGenerateTokenValidUserReturnsJwt(user, validJwt);

            return new AuthService(mockJwtService.Object, mockHashService.Object, mockUserService.Object);
        }

        public static AuthService SigninWithInvalidEmailReturnsInvalidCredentialsError(Auth auth)
        {
            var mockUserService = UserServiceMocks.Mock().SetupGetInvalidEmailReturnsNull(auth.Email);

            return new AuthService(JwtServiceMocks.Mock().Object, HashServiceMocks.Mock().Object, mockUserService.Object);
        }

        public static AuthService SigninWithIncorrectPasswordReturnsInvalidCredentialsError(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService = UserServiceMocks.Mock().SetupGetValidEmailReturnsUser(auth.Email, user);

            var mockHashService = HashServiceMocks.Mock().SetupVerifyLoginAuthIncorrectPasswordReturnsFalse(auth.Password, user.Password);

            return new AuthService(JwtServiceMocks.Mock().Object, mockHashService.Object, mockUserService.Object);
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
        public static AuthService SignupValidCredentialsReturnsSession(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();
            user.Email = auth.Email;

            string validJwt = "valid jwt";

            var mockUserService = UserServiceMocks.Mock()
                .SetupGetInvalidEmailReturnsNull(auth.Email)
                .SetupCreateReturnsUser(user);

            var mockHashService = HashServiceMocks.Mock().SetupHashPasswordReturnsHashedPassword(auth.Password, user.Password);

            var mockJwtService = JwtServiceMocks.Mock().SetupGenerateTokenValidUserReturnsJwt(user, validJwt);

            return new AuthService(mockJwtService.Object, mockHashService.Object, mockUserService.Object);
        }

        public static AuthService SignupWithDuplicateEmailReturnsDuplicateEmailErrors(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService =
                UserServiceMocks.Mock().SetupGetValidEmailReturnsUser(auth.Email, user);

            return new AuthService(JwtServiceMocks.Mock().Object, HashServiceMocks.Mock().Object, mockUserService.Object);
        }

        public static AuthService SignupOnUserCreationFailureReturnsCreationFailedError(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService =
                UserServiceMocks.Mock()
                    .SetupGetInvalidEmailReturnsNull(auth.Email)
                    .SetupCreateReturnsCreationFailedError();

            var mockHashService = HashServiceMocks.Mock().SetupHashPasswordReturnsHashedPassword(auth.Password, user.Password);

            return new AuthService(
                JwtServiceMocks.Mock().Object,
                mockHashService.Object,
                mockUserService.Object);
        }
        public static AuthService SignupOnAuthCreationFailureReturnsAuthCreationFailedError(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService =
                UserServiceMocks.Mock()
                    .SetupGetInvalidEmailReturnsNull(auth.Email)
                    .SetupCreateReturnsUser(user);

            var mockHashService = HashServiceMocks.Mock().SetupHashPasswordReturnsHashedPassword(auth.Password, user.Password);

            var mockJwtService = JwtServiceMocks.Mock().SetupGenerateTokenReturnsAuthCreationFailedError();

            return new AuthService(
                mockJwtService.Object,
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

        public static (AuthService service, Auth auth) SignupOnUserCreationFailureReturnsCreationFailedError()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SignupOnUserCreationFailureReturnsCreationFailedError(auth), auth);
        }
        public static (AuthService service, Auth auth) SignupOnAuthCreationFailureReturnsAuthCreationFailedError()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SignupOnAuthCreationFailureReturnsAuthCreationFailedError(auth), auth);
        }
        #endregion
    }
}
