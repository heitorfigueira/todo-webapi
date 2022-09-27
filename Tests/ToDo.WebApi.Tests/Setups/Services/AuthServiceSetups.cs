using AutoFixture;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;
using ToDo.WebApi.Tests.Unit.Mocks.Services;
using ToDo.WebApi.Tests.Unit.Mocks;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class AuthServiceSetups
    {
        #region Signin
        public static AuthService SigninWithValidCredentialsReturnsSession(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            string validJwt = "valid jwt";

            var mockUserService = UserServiceMocks.Mock().SetupGetValidEmailReturnsUser(user);

            var mockHashService = HashServiceMocks.Mock().SetupVerifyLoginAuthCorrectPasswordReturnsTrue(user.Password, auth.Password);

            var mockJwtService = JwtServiceMocks.Mock().SetupGenerateTokenValidUserReturnsJwt(user, validJwt);

            return new AuthService(mockJwtService.Object, mockHashService.Object, mockUserService.Object, MapperMocks.Mock().Object);
        }

        public static AuthService SigninWithInvalidEmailReturnsInvalidCredentialsError(Auth auth)
        {
            var mockUserService = UserServiceMocks.Mock().SetupGetReturnsNull();

            return new AuthService(JwtServiceMocks.Mock().Object, HashServiceMocks.Mock().Object, mockUserService.Object, MapperMocks.Mock().Object);
        }

        public static AuthService SigninWithIncorrectPasswordReturnsInvalidCredentialsError(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService = UserServiceMocks.Mock().SetupGetValidEmailReturnsUser(user);

            var mockHashService = HashServiceMocks.Mock().SetupVerifyLoginAuthIncorrectPasswordReturnsFalse(user.Password, auth.Password);

            return new AuthService(JwtServiceMocks.Mock().Object, mockHashService.Object, mockUserService.Object, MapperMocks.Mock().Object);
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

            var mockMapper =
                MapperMocks.Mock()
                    .SetupMapAnyReturns<Auth, User>(user);

            string validJwt = "valid jwt";

            var mockUserService =
                UserServiceMocks.Mock()
                    .SetupGetReturnsNull()
                    .SetupCreateReturnsUser(user);

            var mockHashService =
                HashServiceMocks.Mock()
                    .SetupHashPasswordReturnsHashedPassword(user.Password);

            var mockJwtService =
                JwtServiceMocks.Mock()
                    .SetupGenerateTokenValidUserReturnsJwt(user, validJwt);

            return new AuthService(
                mockJwtService.Object,
                mockHashService.Object,
                mockUserService.Object,
                mockMapper.Object);
        }

        public static AuthService SignupWithDuplicateEmailReturnsDuplicateEmailErrors()
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService =
                UserServiceMocks.Mock()
                .SetupGetValidEmailReturnsUser(user);

            return new AuthService(
                JwtServiceMocks.Mock().Object,
                HashServiceMocks.Mock().Object,
                mockUserService.Object,
                MapperMocks.Mock().Object);
        }

        public static AuthService SignupOnUserCreationFailureReturnsCreationFailedError(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockMapper =
                MapperMocks.Mock()
                    .SetupMapAnyReturns<Auth, User>(user);

            var mockHashService =
                HashServiceMocks.Mock()
                    .SetupHashPasswordReturnsHashedPassword(user.Password);

            var mockUserService =
                UserServiceMocks.Mock()
                    .SetupGetReturnsNull()
                    .SetupCreateReturnsCreationFailedError();

            return new AuthService(
                JwtServiceMocks.Mock().Object,
                mockHashService.Object,
                mockUserService.Object,
                mockMapper.Object);
        }
        public static AuthService SignupOnAuthCreationFailureReturnsAuthCreationFailedError(Auth auth)
        {
            var user = UserFakers.GenerateSingleUser();

            var mockUserService =
                UserServiceMocks.Mock()
                    .SetupGetReturnsNull();

            var mockMapper =
                MapperMocks.Mock()
                    .SetupMapAnyReturns<Auth, User>(user);

            var mockHashService =
                HashServiceMocks.Mock()
                    .SetupHashPasswordReturnsHashedPassword(user.Password);

            mockUserService.SetupCreateReturnsUser(user);

            var mockJwtService =
                JwtServiceMocks.Mock()
                    .SetupGenerateTokenReturnsAuthCreationFailedError();

            return new AuthService(
                mockJwtService.Object,
                mockHashService.Object,
                mockUserService.Object,
                mockMapper.Object);
        }

        public static (AuthService service, Auth auth) SignupValidCredentialsReturnsSession()
        {
            var auth = AuthFakers.GenerateSingleAuth();
            return (SignupValidCredentialsReturnsSession(auth), auth);
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
