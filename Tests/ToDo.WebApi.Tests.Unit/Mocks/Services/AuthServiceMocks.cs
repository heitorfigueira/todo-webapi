using AutoFixture;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.DTOs.ValueObject;
using ToDo.WebApi.Application.Fakers;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;
using static ToDo.WebApi.Application.DTOs.Requests.AuthRequests;

namespace ToDo.WebApi.Tests.Unit.Mocks.Services
{
    public static class AuthServiceMocks
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

        public static Mock<IAuthService> SetupSigninWithInvalidCredentialsReturnsCreationFailedError(this Mock<IAuthService> mock, Auth auth)
        {
            mock.Setup(service =>
                    service.Signin(auth))
                    .Returns(Errors.Authentication.InvalidCredentials);

            return mock;
        }
        #endregion

        #region Signup
        public static Mock<IAuthService> MockSignupWithValidCredentialsReturnsSession(Auth auth)
        {
            var mock = new Mock<IAuthService>();
            mock.Setup(service =>
                    service.Signup(auth, null))
                    .Returns(new Session());

            return mock;
        }
        #endregion
    }
}
