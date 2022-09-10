using ToDo.WebApi.Application.Contracts.Services;
using ToDo.WebApi.Domain.Entities;

namespace ToDo.WebApi.Tests.Unit.Setups.Services
{
    public static class JwtServiceSetups
    {
        public static Mock<IJwtService> MockGenerateTokenValidUserReturnsValidJwt(User user, string validJwt)
        {
            var mock = new Mock<IJwtService>();
            mock.Setup(service =>
                service.GenerateTokenFrom(user))
                .Returns(validJwt);

            return mock;
        }
    }
}
