using AutoFixture;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Application.Services;
using ToDo.WebApi.Domain.Entities;
using ToDo.WebApi.Domain;

namespace ToDo.WebApi.Tests.Unit.Mocks.Services
{
    public static class JwtServiceMocks
    {
        #region Generate Token
        public static Mock<IJwtService> SetupGenerateTokenValidUserReturnsJwt(this Mock<IJwtService> mock, User user, string validJwt)
        {
            mock.Setup(service =>
                service.GenerateTokenFrom(user))
                .Returns(validJwt);

            return mock;
        }
        public static Mock<IJwtService> SetupGenerateTokenReturnsAuthCreationFailedError(this Mock<IJwtService> mock)
        {
            mock.Setup(service =>
                service.GenerateTokenFrom(It.IsAny<User>()))
                .Returns(Errors.Authentication.CreationFailed);

            return mock;
        }

        #endregion

        public static Mock<IJwtService> Mock()
        {

            return new Fixture().Create<Mock<IJwtService>>();
        }
    }
}
