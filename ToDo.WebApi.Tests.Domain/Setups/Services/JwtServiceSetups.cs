using AutoFixture;
using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class JwtServiceSetups
    {
        public static Mock<IJwtService> MockGenerateTokenValidUserReturnsJwt(User user, string validJwt)
        {
            var mock = new Mock<IJwtService>();
            mock.Setup(service =>
                service.GenerateTokenFrom(user))
                .Returns(validJwt);

            return mock;
        }

        public static Mock<IJwtService> Mock()
        {

            return new Fixture().Create<Mock<IJwtService>>();
        }
    }
}
